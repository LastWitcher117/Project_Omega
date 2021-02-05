using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch_Scene : MonoBehaviour
{
    public Canvas You_Win_Screen;

    public int nextSceneToLoad;

    public Pause_Menu PM;

    public AnimationController AC;
    
    public GameObject ScorePoints;
    public GameManagerScript gm;
    public TimerCountdown TC;

    public float scoreAmount;
    public float pointIncreasedPersSecond;
    public Text scoreText;
    public Text SnackPoints;

    public Text LoseScorePoints;

    public bool Adder = false;
    public int PointsValueMultiplier;
    public int TimeTakerValue;

    public Health HP;

    public void OnTriggerEnter(Collider other)
    {
        TC.PlayerWon = true;
        PM.isPause = true;
        You_Win_Screen.enabled = true;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);  // FMOD
        FindObjectOfType<AudioManager>().Play("WinSound");
        //Time.timeScale = 0f;

        /*float pauseEndTime = Time.realtimeSinceStartup + 2.5f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;*/

        FindObjectOfType<AudioManager>().Stop("Theme");
        //SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gm.gameIsWon = true;
        TC.InEndScreen = true;

        AC.inTutorial = true;
        PM.enabled = false;
        Adder = true;
        scoreAmount = gm.snackpoints;
    }

    public void Update()
    {
        /*/
        if(Input.GetKeyDown(KeyCode.H))
        {
            Adder = true;
            scoreAmount = gm.snackpoints;
        }
        /*/

        if(HP.health == 0)
        {
            LoseScorePoints.GetComponent<Text>().text = gm.snackpoints.ToString(); 
        }

        if (TC.timeLeft >= TimeTakerValue && TC.PlayerWon == true) //33
        {
            
            if(Adder == true)
            {
                gm.snackpoints = (int)scoreAmount;
                SnackPoints.GetComponent<Text>().text = gm.snackpoints.ToString();

                ScorePoints.GetComponent<Text>().text = (int)scoreAmount + "";

                Adder = false;
                StartCoroutine(EndScreenAdder());
            }
            
        }
        
        if(TC.timeLeft <= 0)
        {
            Time.timeScale = 0f;
        }

        //scoreText.text = (int)scoreAmount + " Score ";
        //scoreAmount += pointIncreasedPersSecond * Time.deltaTime;
    }

    IEnumerator EndScreenAdder()
    {
        yield return new WaitForSeconds(0.00005f);
        scoreAmount += TimeTakerValue * PointsValueMultiplier; 
        Adder = true;
    }
}
