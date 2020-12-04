using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject Enemy;
    public float cooldownTime = 2;
    public float nextDashTime = 0f;

    public void Attack()
    {
        Enemy.GetComponent<EnemyController>().SupressMovement = true;
        Debug.Log("ATTACKING " + Enemy.name);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //TODO: COOLDOWN FOR ATTACK
            Attack();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy = other.gameObject;
            Debug.Log("ENEMY IN RANGE" + Enemy.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Enemy = null;
    }

}

