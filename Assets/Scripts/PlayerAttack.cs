using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyPlaceHolder;

    public Canvas AttackNow;

    public ParticleSystem AttackParticleSystem;

    public AnimationController re;

    /// Cooldown
    bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;

    void Start()
    {
        Enemy = EnemyPlaceHolder;
        ElapsedTime = CooldownTime;
        //playerAttackSound = FMODUnity.RuntimeManager.CreateInstance(eventPath);  // FMOD
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Cooldown == false)
        {
            Cooldown = true;

           // StartCoroutine(AttackDelay());

            re.isAttacking = true;
            StartCoroutine(AttackAniamtion());

            AttackParticleSystem.Play();

            StartCoroutine(AttackDelay());        
            
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

            Debug.Log("ENEMY IN RANGE ");
            StartCoroutine(Waiter());

        }
        else
        {
            Debug.Log(" No enemy in range ");
        }
    }

        public void Attack()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Attack/PlayeerAttack_Dagger"); // FMOD


        if (Enemy.GetComponent<EnemyController>() != null) 
        {
            Enemy.GetComponent<EnemyController>().SupressMovement = true;
        }
        if (Enemy.GetComponent<EnemyController>() == null)
        {
            Debug.Log("no enemy in range");
        }

        if(Enemy.GetComponent<GuardianPatrol>() != null)
        {
            Enemy.GetComponent<GuardianPatrol>().SupressMovement = true;
        }
        if (Enemy.GetComponent<GuardianPatrol>() == null)
        {
            Debug.Log("no enemy in range2222222");
        }


        Debug.Log("ATTACKING " + Enemy.name);
        //FindObjectOfType<AudioManager>().Play("PlayerAttack");
        
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.4f);

        Attack();
        AttackNow.enabled = false;

    }

    IEnumerator Waiter() //Time Active of Attack Now Screen
    {
        yield return new WaitForSeconds(1f);
        AttackNow.enabled = false;

    }

    IEnumerator AttackAniamtion()
    {
        yield return new WaitForSeconds(0.6f);
        re.isAttacking = false;
    }

    void OnTriggerExit(Collider other)
    {
        Enemy = EnemyPlaceHolder;
    }

}

