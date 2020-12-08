using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    GameObject Enemy;

    public Canvas AttackNow;

    /// Cooldown
    bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;

    void Start()
    {
        ElapsedTime = CooldownTime;
    }

    public void Attack()
    {
        Enemy.GetComponent<EnemyController>().SupressMovement = true;
        Debug.Log("ATTACKING " + Enemy.name);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Cooldown == false)
        {
            Cooldown = true;
            FindObjectOfType<AudioManager>().Play("PlayerAttack");
            Attack();
            AttackNow.enabled = false;
        }

        if (Cooldown == true)
        {
            ElapsedTime -= Time.deltaTime;

            if (ElapsedTime <= 0f)
            {
                Cooldown = false;
                ElapsedTime = CooldownTime;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy = other.gameObject;
            AttackNow.enabled = true;
            Debug.Log("ENEMY IN RANGE" + Enemy.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Enemy = null;
    }
}

