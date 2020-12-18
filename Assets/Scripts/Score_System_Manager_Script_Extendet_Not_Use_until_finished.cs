using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_System_Manager_Script_Extendet_Not_Use_until_finished : MonoBehaviour
{
     //Connection to the Gameobjects with scoretexts
    public GameObject score1Object;
public GameObject score2Object;
public GameObject score3Object;

//PlayerPrefKeys
string FirstHighscoreKey;
string ListSlot1Key;
string ListSlot2Key;
string ListSlot3Key;

//input for the ScoreMenu texts
public string score1 = "1. xxx";
public string score2 = "2. xxx";
public string score3 = "3. xxx";

//ints for text input and for PlayerPrefs Input
int finalInt1;
int finalInt2;
int finalInt3;

public int lastHighscore;

// Start is called before the first frame update
void Start()
{


    //sorting the Score List
    lastHighscore = PlayerPrefs.GetInt(FirstHighscoreKey);
    int score1int = PlayerPrefs.GetInt(ListSlot1Key, 0);
    int score2int = PlayerPrefs.GetInt(ListSlot2Key, 0);
    Debug.Log("score2int: " + score2int);
    int score3int = PlayerPrefs.GetInt(ListSlot3Key, 0);
    Debug.Log(", score3Int: " + score3int);
    if (lastHighscore > score1int)
    {

        score3int = score2int;
        score2int = score1int;
        score1int = lastHighscore;

    }
    else
    {
        Debug.Log("No Score Changes!");

    }

    //Set final ints

    finalInt1 = score1int;
    finalInt2 = score2int; // falsche Zahl
    finalInt3 = score3int; // falsche Zahl


    //Fill the List 
    score1 = "1. " + finalInt1 + " Points";
    score2 = "2. " + finalInt2 + " Points";
    score3 = "3. " + finalInt3 + " Points";

    // The PlayerPrefs are filled with ints from finalInt1 - 3
    PlayerPrefs.SetInt(ListSlot1Key, finalInt1);
    //PlayerPrefs.SetInt(ListSlot2Key, finalInt2);
    //PlayerPrefs.SetInt(ListSlot3Key, finalInt3);
    PlayerPrefs.Save();
}

// Update is called once per frame
void Update()
{



    int score1int = PlayerPrefs.GetInt(ListSlot1Key);
    int score2int = PlayerPrefs.GetInt(ListSlot2Key);
    int score3int = PlayerPrefs.GetInt(ListSlot3Key);

    Debug.Log("last Hoghscore: " + lastHighscore + ", score1Int: " + score1int);
    if (lastHighscore > score1int)
    {
        Debug.Log("lastHighscore war größer als score1Ind");
        score3int = score2int;
        score2int = score1int;
        score1int = lastHighscore;
        Debug.Log("score1Int: " + score1int);


        //Set final ints

        finalInt1 = score1int;
        finalInt2 = score2int;
        finalInt3 = score3int;
        Debug.Log("finalInt1: " + finalInt1);

        //Fill the List 
        score1 = "1. " + finalInt1 + " Points";
        score2 = "2. " + finalInt2 + " Points";
        score3 = "3. " + finalInt3 + " Points";

        PlayerPrefs.SetInt(ListSlot1Key, finalInt1);
        Debug.Log("Pref Listslot1: " + PlayerPrefs.GetInt(ListSlot1Key));
        // PlayerPrefs.SetInt(ListSlot2Key, finalInt2);
        // PlayerPrefs.SetInt(ListSlot3Key, finalInt3);
        PlayerPrefs.Save();
        Debug.Log("Pref Listslot1 after save: " + PlayerPrefs.GetInt(ListSlot1Key));
    }
    else
    {
        Debug.Log("No Score Changes!");

    }

    //Debug.Log("1: " + score1int + " 2: " + score2int + " 3: " + score3int);

}
}
