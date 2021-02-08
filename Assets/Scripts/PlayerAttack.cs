using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyPlaceHolder;

    public bool TutorialAttack = false;

    public Canvas AttackNow;

    public ParticleSystem AttackParticleSystem;

    public AnimationController re;

    public GameManagerScript GMS;


    /// Cooldown
    public bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;

    //FMOD
    //bool waitPlay = false;

    void Start()
    {
        Enemy = EnemyPlaceHolder;
        ElapsedTime = CooldownTime;
        //playerAttackSound = FMODUnity.RuntimeManager.CreateInstance(eventPath);  // FMOD
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Cooldown == false && re.inTutorial == false && re.isDashing == false && GMS.TutorialWeapon == false)
        {
            Cooldown = true;
            re.AttacktoDashFix = true;

            if (TutorialAttack == true)
            {
                Debug.Log("Its learning time.");
            }
            else
            {
                re.isAttacking = true;
                re.Attack = true;
                StartCoroutine(AttackAniamtion());

                AttackParticleSystem.Play();

                StartCoroutine(AttackDelay());
            }
        }

        if (Cooldown == true)
        {
            ElapsedTime -= Time.deltaTime;

            if (ElapsedTime <= 0f)
            {
                Cooldown = false;
                re.Attack = false;
                ElapsedTime = CooldownTime;

                re.AttacktoDashFix = false;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            Enemy = other.gameObject;

            AttackNow.enabled = true;
            if (AttackNow.enabled == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy/EnemyAttackAlert");
                //Debug.Log("mucho mucho play");
            }

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
            Debug.Log("no enemy in range");
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

