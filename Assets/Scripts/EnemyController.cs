using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    float SupressTime;
    public float StunTime;

    public float lookRadius = 10f;
    public float SpeedStop;
    public float SpeedNormal = 13f;

    Transform target;
    NavMeshAgent agent;

    public bool SupressMovement;

    public ParticleSystem VFXStunOverHead;
    public ParticleSystem VFXStunSparks;

    public GameObject StartPoint;

    public AnimationController AC;
    public PlayerAttack PA;
  
    //---Fmod
    public float LookRadiusDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        return distance;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(SupressMovement)
        {
            VFXStunOverHead.Play();
            VFXStunSparks.Play();

            SupressTime += Time.deltaTime;
            if (SupressTime >= StunTime)
            {
                SupressTime = 0f;
                VFXStunOverHead.Clear();
                VFXStunOverHead.Stop();


                VFXStunSparks.Clear();
                VFXStunSparks.Stop();
                SupressMovement = false;
            }
        }

        if (distance <= lookRadius && !SupressMovement)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                FaceTarget();
            }
        }

        if(distance >= lookRadius && !SupressMovement)
        {
            Vector3 PathToStartPoint = (StartPoint.transform.position);
            agent.SetDestination(PathToStartPoint);
            
        }


        if (distance <= 1.0f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (PA.AttackNow.enabled == true && AC.inTutorial == true)
        {
            agent.speed = 0f;
        }
        if (PA.AttackNow.enabled == false && AC.inTutorial == false)
        {
            agent.speed = 13f;
        }

    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
