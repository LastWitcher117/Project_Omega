using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_to_Pacsy : MonoBehaviour
{

    public GameObject LetterToPacsy;

    public AnimationController AC;

    public Pause_Menu PM;

    public bool InLetter = false;

    public bool Switch = false;

    FMOD.Studio.Bus MasterBus;

    private void OnTriggerEnter(Collider other)
    {
        PM.GameIsPaused = true;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InLetter == true)
        {

            AC.inTutorial = false;
            LetterToPacsy.gameObject.SetActive(false);

            MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");



            //Stop/break of the Audio here | Yes even if it interreupts the audio ;) 
            //cause the player is able to walk inside the letter again if he skips it accidentally :D
        }
    }

    private void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");

        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
