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

    public int timeLeft = 360;

    public bool takingAway = false;

    public bool PlayerWon = false;
    public bool noTimeLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "" + timeLeft;
        PlayerWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        if (takingAway == false && timeLeft > 0)
        {
            StartCoroutine(TimerTake());
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

    IEnumerator LoseScreen()
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
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1);
    }

}
