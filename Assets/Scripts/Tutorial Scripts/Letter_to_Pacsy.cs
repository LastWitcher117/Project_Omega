using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_to_Pacsy : MonoBehaviour
{

    public GameObject LetterToPacsy;
    
    public GameObject Letter_To_Pacsy_Trigger;

    public AnimationController AC;

    public Pause_Menu PM;

    public bool InLetter = false;

    public bool Switch = false;

    public bool FirstTimeSpace = false;

    public Animator PacsysLetterReadSpeed;

    public bool ReadSpeedToSlow = false;

    //FMOD.Studio.Bus MasterBus;

    private void OnTriggerEnter(Collider other)
    {
        PM.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (Switch == false)
        {
            LetterToPacsy.gameObject.SetActive(true);
            AC.inTutorial = true;
            InLetter = true;
            Switch = true;
        }

        //Play Audio "Pacmans_Letter_To_Pacsy" here
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Letter_To_Pacsy");

    }

    private void OnTriggerExit(Collider other)
    {
        Switch = false;
        Letter_To_Pacsy_Trigger.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InLetter == true)
        {

            PacsysLetterReadSpeed.speed = 1000f;
            StartCoroutine(SpaceWaiter());
        }

            if (Input.GetKeyDown(KeyCode.Space) && InLetter == true && FirstTimeSpace == true)
            {
                PM.enabled = true;
                AC.inTutorial = false;
                LetterToPacsy.gameObject.SetActive(false);

                Letter_To_Pacsy_Trigger.SetActive(false);

            }

            if(ReadSpeedToSlow == true)
            {
                ReadSpeedToSlow = false;
                PacsysLetterReadSpeed.speed = 1f;
            }

    }

    IEnumerator SpaceWaiter()
    {
        yield return new WaitForSeconds(0.5f);
        FirstTimeSpace = true;
    }

}
