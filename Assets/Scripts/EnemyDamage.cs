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

    public LightingBarrier LB;

    void Start()
    {
        ElapsedTime = CooldownTime;
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isOnCooldown == false && inTowerTP == false && insideAttackCollider == false) //&& Cooldown == false
        {                    
           
            isOnCooldown = true;
            insideAttackCollider = true;    

            HP.health--;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);
            EnemyAttack.SetActive(true);


            Dmg_Flashscreen.SetActive(true); //Activating red Screen      
            
            StartCoroutine(RedDamageScreenWaiter());


            //FindObjectOfType<AudioManager>().Play("EnemyAttack");
            //FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)
        }
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnCooldown = true;          
            StartCoroutine(AttackWaiter());
            
        }
        
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    private void OnTriggerExit(Collider other)
    {
       // insideAttackCollider = false;
        StopCoroutine(AttackWaiter());
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    IEnumerator RedDamageScreenWaiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);
        
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

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
        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if (CGOT_Blue == true || CGOT_Green == true || CGOT_Orange == true || CGOT_Pruple == true)
        {
            inTowerTP = false;
        }

        if(CGOT_Blue == false && CGOT_Green == false && CGOT_Orange == false && CGOT_Pruple == false)
        {
            inTowerTP = true;
        }

        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if (isOnCooldown == true)
        {
            StartCoroutine(CooldownRefresher());
        }

        /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

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

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    IEnumerator AttackWaiter()
    {
        
        yield return new WaitForSeconds(CooldownTime);

        if (insideAttackCollider == true && isOnCooldown == false)
        {
            EnemyAttack.SetActive(true);
            HP.health--;

            EnemyAttack.SetActive(false);
            Dmg_Flashscreen.SetActive(true);       

            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Enemy/EnemyAttack", gameObject);           
            StartCoroutine(RedDamageScreenWaiter());

            //FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)
        }
    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/

    IEnumerator CooldownRefresher()
    {
        yield return new WaitForSeconds(CooldownTime);
        isOnCooldown = false;

    }

    /*/------------------------------------------------------------------------------------------------------------------------------------------------------------/*/
}

