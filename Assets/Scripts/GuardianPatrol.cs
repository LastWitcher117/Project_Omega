using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianPatrol : MonoBehaviour
{

    //Agent waiting on each node.
    [SerializeField]
    bool _patrolWaiting;

    //Total wait time of agent.
    [SerializeField]
    float _totalWaitTime = 3f;

    //Probability of switching direction.
    [SerializeField]
    float _switchProbability = 0.2f;

    //List of all patrol points to visit.
    [SerializeField]
    List<Waypoints> _patrolPoints;

    //Particle Systems
    public ParticleSystem ExclamationMark;
    public ParticleSystem QuestionMark;

    //Private variables 
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;

    //Public variables
    public float isSeeingPlayer = 0f;

    //Enemy Controller variables
    float SupressTime;
    public float StunTime;

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public bool SupressMovement;

    public ParticleSystem Stun;

    public float distance;


 
    //---Fmod
    FMOD.Studio.EventInstance enemyStunnedSound;
    FMOD.Studio.PLAYBACK_STATE enemyStunnedSoundState;
    Transform fTransform;
    Rigidbody fRigidBody;
    float playEnemyStunned = 0;

    public int FollowingPlayer = 0; // from Héctor

    public float LookRadiusDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        return distance;
    }


    private void Start()
    {
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent is not attached to " + gameObject.name);
        }
        else
        {
            if(_patrolPoints!= null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behavior.");
            }
        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/

        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        //FMOD
        enemyStunnedSound = FMODUnity.RuntimeManager.CreateInstance("event:/Enemy/EnemyStunned2");
        fTransform = GetComponent<Transform>();
        fRigidBody = GetComponent<Rigidbody>();


    }

    public void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        //FMOD
        enemyStunnedSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(fTransform, fRigidBody));
        enemyStunnedSound.getPlaybackState(out enemyStunnedSoundState);

        if (distance >= lookRadius && !SupressMovement)
        {
            //Check if we're going to the destination.
            if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
            {
                _travelling = false;

                //If we're going to wait, then wait.
                if (_patrolWaiting)
                {
                    _waiting = true;
                    _waitTimer = 0f;
                }
                else
                {
                    ExclamationMark.Stop();
                    ExclamationMark.Clear();
                    QuestionMark.Play();

                    isSeeingPlayer = 0f;

                    ChangePatrolPoint();                 
                    SetDestination();
                }
            }

            //Instead if we're waiting.
            if (_waiting)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _totalWaitTime)
                {
                    _waiting = false;

                    ChangePatrolPoint();
                    SetDestination();
                }
            }
        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        else
        {
            ExclamationMark.Play();
            QuestionMark.Stop();
            QuestionMark.Clear();

            isSeeingPlayer++; ;

            if (isSeeingPlayer == 1f)
            {
                
                FindObjectOfType<AudioManager>().Play("GuardianNotice");
                
            }
            if (SupressMovement)
            {
                Stun.Play();

                //FMOD
                /*if (enemyStunnedSoundState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
                {
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
                    enemyStunnedSound.start();
                    Debug.Log("CUANTOS GUARDIAN PATROL MAREADOS?!!");
                }*/
                if (playEnemyStunned <= SupressTime)
                {
                    if (enemyStunnedSoundState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
                    {
                        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
                        enemyStunnedSound.start();
                        Debug.Log("CUANTOS GUARDIAN PATROL MAREADOS?!!");
                    }
                }

                SupressTime += Time.deltaTime;
                if (SupressTime >= StunTime)
                {
                    SupressTime = 0f;
                    Stun.Clear();
                    Stun.Stop();
                    SupressMovement = false;
                    //FMOD
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
                }
            }

            if (distance <= lookRadius && !SupressMovement)
            {

                agent.SetDestination(target.position);
                FollowingPlayer = 1; // From Héctor
                // Debug.Log("Following");

                if (distance <= agent.stoppingDistance)
                {
                    // Attack the target
                    
                    FaceTarget();
                }
            }

            else // From Héctor
            {
                FollowingPlayer = 0;
                // Debug.Log("Not Following");
            }

            if (distance <= 1.0f)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
    }

    /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/

void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(10000000f);
    }


    private void SetDestination()
    {
        if(_patrolPoints!=null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }

    ///<summary>
    ///Selects a new patrol point in the available list, but
    ///also with a small probability allows to move forward or backwards.
    /// </summary>
    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if(_patrolForward)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            if(--_currentPatrolIndex < 0)
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }
}
