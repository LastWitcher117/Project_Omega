using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightingBarrier : MonoBehaviour
{
    public GameObject Lightning;
    public GameObject LightningDamageDealer;

    public DoorTrigger DT;
    public Health HP;
    public Pause_Menu PM;
    public ThirdPersonMovement ay;

    public GameObject Dmg_Flashscreen;
    public Canvas You_Lose_Screen;

    public bool tookDamage = false;
    public bool WasGoingAway = false;


    // Update is called once per frame
    void Update()
    {
        if(DT.hasKey == true)
        {
            Lightning.SetActive(false);
            LightningDamageDealer.SetActive(false);
        }

        if(HP.health == 0)
        {
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

    private void OnTriggerEnter(Collider other)
    {
        WasGoingAway = false;
        HP.health--;

        tookDamage = true;
        Dmg_Flashscreen.SetActive(true);
        StartCoroutine(Waiter());
    }

    private void OnTriggerStay(Collider other)
    {
        if(tookDamage == true)
        {
            tookDamage = false;
            StartCoroutine(LightningDMG());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WasGoingAway = true;
    }

    IEnumerator Waiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);

    }

    IEnumerator LoseScreen() //Time Active of red DMG Screen
    {
        ay.enabled = false;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 3.2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line
    }

    IEnumerator LightningDMG()
    {
        
            yield return new WaitForSeconds(2f);
        if (WasGoingAway == false)
        {
            HP.health--;
            Dmg_Flashscreen.SetActive(true);
            StartCoroutine(Waiter());
            tookDamage = true;
        }
       
    }

}
