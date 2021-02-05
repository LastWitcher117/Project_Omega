
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_System_Script : MonoBehaviour
{
    public GameManagerScript gm;
    public Switch_Scene SS;
    public TimerCountdown TC;

    public int score;
    public int highscore;
    string highscoreKey;
    string FirstHighscoreKey;
    public GameObject newHighscoreSprite;

    public bool AfterCountingTime = false;
    

    public GameObject highscorePoints;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt(highscoreKey, 0);

        
        if (gm == null)
        {
            Debug.LogWarning("Der GameManager ist nicht mit dem Score_System_Script verknüpft! LG Big Mama");
        }

        if (highscorePoints == null)
        {
            Debug.LogWarning("Das GameObjact *HighscorePoints* im win_screen Canvas ist nicht mit dem Score_System_Script verknüpft! LG Big Mama");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameIsWon == true)
        {
            HighscoreCheck();
        }
    }

    void HighscoreCheck()
    {
        highscorePoints.GetComponent<Text>().text = highscore.ToString();

        score = (int)SS.scoreAmount;

        if(score > highscore && AfterCountingTime == true)
        {
            TC.FinalEndScore -= SS.TimeTakerValue * SS.PointsValueMultiplier;
            PlayerPrefs.SetInt(highscoreKey, (int)TC.FinalEndScore);
           // PlayerPrefs.SetInt(FirstHighscoreKey, score);
            PlayerPrefs.Save();
            newHighscoreSprite.SetActive(true);
        }
    }
}
