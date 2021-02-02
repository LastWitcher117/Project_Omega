using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Canvas You_Lose_Screen;
    bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;

    public bool tookDamage = false;

    public GameObject Dmg_Flashscreen;

    public AnimationController re;

    public Pause_Menu PM;

    public ThirdPersonMovement ay;

    public GameObject Attack;

    public Animator EnemyAnim;

    public Health HP;


    void Start()
    {
        ElapsedTime = CooldownTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Cooldown == false) //&& Cooldown == false
        {          
            //FindObjectOfType<AudioManager>().Play("EnemyAttack");
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);


            tookDamage = true;
            HP.health--;

            Attack.SetActive(true);
            Dmg_Flashscreen.SetActive(true); //Activating red Screen

            Cooldown = true;
            FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)

            StartCoroutine(Waiter());

          
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Cooldown == false)
        {
            Cooldown = true;
            tookDamage = false;
            StartCoroutine(AttackWaiter());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        tookDamage = false;
    }


    IEnumerator Waiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);
        
    }

    IEnumerator LoseScreen() //Time Active of red DMG Screen
    {
        Cursor.lockState = CursorLockMode.None;
        ay.enabled = false;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 3.2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
       
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line
    }

    void Update()
    {
        if (Cooldown == true)
        {
            ElapsedTime -= Time.deltaTime;
            if (ElapsedTime <= 0f)
            {
                Cooldown = false;
                Attack.SetActive(false);
                ElapsedTime = CooldownTime;
            }
        }

        if (HP.health == 0)
        {
            EnemyAnim.SetBool("PlayerDead", true);

            PM.isPause = true;
            You_Lose_Screen.enabled = true;

            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("LoseSound");
            //FMOD  
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 0); // new line
            StartCoroutine(LoseScreen());

        }

    }

    IEnumerator AttackWaiter()
    {
        Attack.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Attack.SetActive(false);
        HP.health--;
        Dmg_Flashscreen.SetActive(true);

        
        Dmg_Flashscreen.SetActive(true); //Activating red Screen

        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);
        FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)

        StartCoroutine(Waiter());
        tookDamage = true;
    }

}

