using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Canvas You_Lose_Screen;
    
    float ElapsedTime;
    public float CooldownTime;

    public bool insideAttackCollider = false;
    public bool inTowerTP = false;
    public bool isOnCooldown; //Cooldown for attack

    public GameObject Dmg_Flashscreen;

    public AnimationController re;

    public Pause_Menu PM;

    public ThirdPersonMovement ay;

    public GameObject EnemyAttack;

    public Animator EnemyAnim;

    public Health HP;

    public CameraGoingOnTower CGOT_Blue;
    public CameraGoingOnTower CGOT_Orange;
    public CameraGoingOnTower CGOT_Pruple;
    public CameraGoingOnTower CGOT_Green;

    public float Cooldown = 3.5f;
    public float Timer = 0f;
    public float time;
    public bool AttackMode = false;

    public bool PlayerIsDead;
    public bool InTutorialScene;

    public LightingBarrier LB;

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && inTowerTP == false && insideAttackCollider == false) //&& Cooldown == false
        {                    
           
            isOnCooldown = true;
            insideAttackCollider = true;
            Attack();

            /*/
            HP.health--;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);
            EnemyAttack.SetActive(true);

            Dmg_Flashscreen.SetActive(true); //Activating red Screen                 
            StartCoroutine(RedDamageScreenWaiter());
            /*/

            //FindObjectOfType<AudioManager>().Play("EnemyAttack");
            //FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)
        }
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    private void OnTriggerStay(Collider other)
    {
       // insideAttackCollider = true;
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    private void OnTriggerExit(Collider other)
    {
        isOnCooldown = true;
        Timer = Time.time + 1;

        //Timer += Cooldown;
        if (insideAttackCollider == true)
        {
            StartCoroutine(EnterAttackTrigger());
        }
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    IEnumerator RedDamageScreenWaiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);
        
    }


    void Update()
    {


        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if (CGOT_Blue.TPNoDMG == true || CGOT_Green.TPNoDMG == true || CGOT_Orange.TPNoDMG == true || CGOT_Pruple.TPNoDMG == true)
        {
            inTowerTP = true;
        }

        if(CGOT_Blue.TPNoDMG == false && CGOT_Green.TPNoDMG == false && CGOT_Orange.TPNoDMG == false && CGOT_Pruple.TPNoDMG == false)
        {
            inTowerTP = false;
        }

        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/
        time = Time.time;

        if (isOnCooldown == false && insideAttackCollider == true)
        {
            if(Time.time > Timer)
            {
               Attack();               
            }
        }

        if(isOnCooldown == true)
        {
            Timer = Time.time + Cooldown;
            isOnCooldown = false;
        }
        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if(HP.health == 0)
        {
            PlayerIsDead = true;
            EnemyAnim.SetBool("PlayerDead", true);
        }

    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    IEnumerator LoseScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        ay.enabled = false;
        EnemyAnim.SetBool("PlayerDead", true);

        PM.enabled = false;
        You_Lose_Screen.enabled = true;

        //FindObjectOfType<AudioManager>().Stop("Theme");
        //FindObjectOfType<AudioManager>().Play("LoseSound");

        yield return new WaitForSeconds(4f);

        //FMOD  
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 0); // new line

        PM.isPause = true;

        Time.timeScale = 0f;

        
  
        /*/
       
       float pauseEndTime = Time.realtimeSinceStartup + 3.2f;
       while (Time.realtimeSinceStartup < pauseEndTime)
       {
           yield return 0;
       }
       Time.timeScale = 1f;

       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
       FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line
       /*/
    }

    public void Attack()
    {
        if (PlayerIsDead == false && InTutorialScene == false)
        {
            isOnCooldown = true;
            EnemyAttack.SetActive(true);
            HP.health--;
         
            Dmg_Flashscreen.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);           
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Player/Pain", gameObject);

            StartCoroutine(RedDamageScreenWaiter());
            StartCoroutine(VFXWaiter());
        }
    }
    
    IEnumerator VFXWaiter()
    {
        yield return new WaitForSeconds(2f);
        EnemyAttack.SetActive(false);
    }

    IEnumerator EnterAttackTrigger()
    {
        yield return new WaitForSeconds(2f);
        insideAttackCollider = false;
    }

}

