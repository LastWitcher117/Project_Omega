using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Enemy;

    public Canvas AttackNow;

    public ParticleSystem AttackParticleSystem;


    

    /// Cooldown
    bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;

    void Start()
    {
        ElapsedTime = CooldownTime;
        //playerAttackSound = FMODUnity.RuntimeManager.CreateInstance(eventPath);  // FMOD
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Cooldown == false)
        {
            Cooldown = true;
            
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

            Debug.Log("ENEMY IN RANGE " + Enemy.name);       
            StartCoroutine(Waiter());
        }
    }

    public void Attack()
    {
        AttackParticleSystem.Play();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Attack/PlayeerAttack_Dagger"); // FMOD

        if (Enemy.GetComponent<EnemyController>() == null)
        {
            Enemy.GetComponent<GuardianPatrol>().SupressMovement = true;
        }
        else
        {
            Enemy.GetComponent<EnemyController>().SupressMovement = true;
        }

        
        
        Debug.Log("ATTACKING " + Enemy.name);
        //FindObjectOfType<AudioManager>().Play("PlayerAttack");
        
    }


    IEnumerator Waiter() //Time Active of Attack Now Screen
    {
        yield return new WaitForSeconds(1f);
        AttackNow.enabled = false;
    }


    void OnTriggerExit(Collider other)
    {
        Enemy = null;
    }

    
}

