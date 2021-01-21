using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_to_Pacsy : MonoBehaviour
{

    public GameObject LetterToPacsy;

    public AnimationController AC;

    public bool InLetter = false;

    public bool Switch = false;

    private void OnTriggerEnter(Collider other)
    {
        if (Switch == false)
        {
            LetterToPacsy.gameObject.SetActive(true);
            AC.inTutorial = true;
            InLetter = true;
            Switch = true;
        }
        //Play Audio "Pacmans_Letter_To_Pacsy" here
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

            //Stop/break of the Audio here | Yes even if it interreupts the audio ;) 
            //cause the player is able to walk inside the letter again if he skips it accidentally :D
        }

    }

}
