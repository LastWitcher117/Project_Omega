using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public Canvas You_Lose_Screen;

    public ThirdPersonMovement ay;
    public Pause_Menu PM;   
    public AnimationController AC;
    public GameManagerScript GMS;
    public Switch_Scene SS;
    public Score_System_Script SSS;

    public int timeLeft = 360;
    public float FinalEndScore;

    public bool takingAway = false;

    public bool PlayerWon = false;
    public bool noTimeLeft = false;

    public bool InEndScreen = false;


    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "" + timeLeft;
        PlayerWon = false;
        InEndScreen = false;
    }

    // Update is called once per frame
    void Update()
    {   
        
        /*/
        if(Input.GetKeyDown(KeyCode.H))
        {
            InEndScreen = true;
            PlayerWon = true;
        }
        /*/

        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        if (InEndScreen == false)
        {
            if (takingAway == false && timeLeft > 0 && PlayerWon == false)
            {
                StartCoroutine(TimerTake());
            }
        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/

        if(InEndScreen == true &&  timeLeft >= SS.TimeTakerValue && PlayerWon == true) //33
        {
            takingAway = true;
            StartCoroutine(TimerTakeEndScreen());

        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        if (timeLeft <=(SS.TimeTakerValue - 1) && PlayerWon == true) //33
        {
            textDisplay.GetComponent<Text>().text = "" + 0;

            FinalEndScore = SS.scoreAmount ;
            
            SSS.AfterCountingTime = true;
            Time.timeScale = 0f;
        }
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        if (timeLeft == 0)
        {
            /*/
            AC.isDying = true;
            PM.isPause = true;
            You_Lose_Screen.enabled = true;

            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("LoseSound");
            //FMOD  
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 0);

            StartCoroutine(LoseScreen());
            /*/

            noTimeLeft = true;

        }

        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        /*/
        if (PlayerWon == true && noTimeLeft == false)
        {
            GMS.snackpoints = GMS.snackpoints + (timeLeft * 3);
            PlayerWon = false;
        }

        if (PlayerWon == true && noTimeLeft == true)
        {
            GMS.snackpoints = GMS.snackpoints + (timeLeft * 1);
            PlayerWon = false;
        }
        /*/
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
    }

    IEnumerator TimerTake()
    {

        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        textDisplay.GetComponent<Text>().text = ""+ timeLeft;
        takingAway = false;

    }
    /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
    IEnumerator TimerTakeEndScreen()
    {
        InEndScreen = false;
        yield return new WaitForSeconds(0.00005f);
        timeLeft -= SS.TimeTakerValue; //33
        textDisplay.GetComponent<Text>().text = "" + timeLeft;
        InEndScreen = true;
    }

}
