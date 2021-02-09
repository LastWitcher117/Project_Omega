using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightingBarrier : MonoBehaviour
{
    public GameObject Lightning1;
    public GameObject Lightning2;

    public ParticleSystem Lighning11;
    public ParticleSystem Lighning12;
    public ParticleSystem Lighning13;
    public ParticleSystem Lighning14;
    public ParticleSystem Lighning15;
    public ParticleSystem Lighning16;

    public ParticleSystem Lighning21;
    public ParticleSystem Lighning22;
    public ParticleSystem Lighning23;
    public ParticleSystem Lighning24;
    public ParticleSystem Lighning25;
    public ParticleSystem Lighning26;


    public Collider LightningDamageDealer;


    public GameObject AfterLightning;


    public GameObject CameraToDoor;
    public GameObject PassingCamera;
    public GameObject ThirdPersonCamera;
    public GameObject DoorBlocker;


    public DoorTrigger DT;
    public Health HP;
    public Pause_Menu PM;
    public ThirdPersonMovement ay;
    public AnimationController AC;
    public CameraGoingOnTower CGOT;

    public GameObject Dmg_Flashscreen;
    public Canvas You_Lose_Screen;


    public bool tookDamage = false;
    public bool WasGoingAway = false;
    public bool CutsceneWasPlayed = false;
    public bool inCutscene = false;

// Update is called once per frame
void Update()
    {
       /*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DT.hasKey = true;
        }
        /*/

        if(DT.hasKey == true && CutsceneWasPlayed == false)
        {

            CutsceneWasPlayed = true;
            CGOT.TPNoDMG = true;
            CutsceneStart();
            
        }

        if(HP.health == 0)
        {
            StartCoroutine(LoseScreen());
        }

    }


 




    private void OnTriggerEnter(Collider other)
    {
        WasGoingAway = false;
        HP.health--;
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Player/Pain", gameObject);

        
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
        Cursor.lockState = CursorLockMode.None;
        ay.enabled = false;

        PM.enabled = false;
        You_Lose_Screen.enabled = true;

        //FindObjectOfType<AudioManager>().Stop("Theme");
        //FindObjectOfType<AudioManager>().Play("LoseSound");

        yield return new WaitForSeconds(4f);

        //FMOD  
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 0); // new line

        Time.timeScale = 0f;
    }

        IEnumerator LightningDMG()
    {
        
            yield return new WaitForSeconds(2f);
        if (WasGoingAway == false)
        {
            HP.health--;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Player/Pain", gameObject);
            Dmg_Flashscreen.SetActive(true);
            StartCoroutine(Waiter());
            tookDamage = true;
        }
       
    }

    public void CutsceneStart()
    {
        CutsceneWasPlayed = true;
        inCutscene = true;

        CameraToDoor.SetActive(false);
        ThirdPersonCamera.SetActive(false);
        PassingCamera.SetActive(true);

        StartCoroutine(PassingToBarrier());

        AC.inTutorial = true;

    }

    IEnumerator PassingToBarrier()
    {

        yield return new WaitForSeconds(3f);

        ThirdPersonCamera.SetActive(false);        
        PassingCamera.SetActive(false);
        CameraToDoor.SetActive(true);


        AfterLightning.SetActive(true);
        StartCoroutine(DeactivateLightning());

    }


    IEnumerator DeactivateLightning()
    {
        
        yield return new WaitForSeconds(3.5f);

        Lightning1.SetActive(false);
        Lightning2.SetActive(false);

        StopLightning();

        

        StartCoroutine(BarrierToPassing());

    }

    IEnumerator BarrierToPassing()
    {
        yield return new WaitForSeconds(1.5f);

        ThirdPersonCamera.SetActive(false);
        CameraToDoor.SetActive(false);
        PassingCamera.SetActive(true);

        StartCoroutine(CutsceneEnd());

    }

    IEnumerator CutsceneEnd()
    {
        yield return new WaitForSeconds(2f);

        CameraToDoor.SetActive(false);
        PassingCamera.SetActive(false);
        ThirdPersonCamera.SetActive(true);

        AC.inTutorial = false;
        inCutscene = false;
        yield return new WaitForSeconds(4);
        CGOT.TPNoDMG = false;
    }

    void StopLightning()
    {
        Lighning11.Stop();
        Lighning12.Stop();
        Lighning13.Stop();
        Lighning14.Stop();
        Lighning15.Stop();
        Lighning16.Stop();

        Lighning21.Stop();
        Lighning22.Stop();
        Lighning23.Stop();
        Lighning24.Stop();
        Lighning25.Stop();
        Lighning26.Stop();

        LightningDamageDealer.enabled = false;
        DoorBlocker.SetActive(false);
    }

}
