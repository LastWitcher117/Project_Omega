
using UnityEngine;



public class Score_System_Manager_Script : MonoBehaviour
{

    string highscoreKey;
    public int lastHighscore;

    // Start is called before the first frame update
    void Start()
    {


        //sorting the Score List
        lastHighscore = PlayerPrefs.GetInt(highscoreKey, 0);
    }
}
