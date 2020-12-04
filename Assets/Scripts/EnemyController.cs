using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    float SupressTime;
    public float StunTime;

    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;

    public bool SupressMovement;
    
    
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
            SupressTime += Time.deltaTime;
            if(SupressTime >= StunTime)
            {
                SupressTime = 0f;
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

        if (distance <= 1.0f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
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
