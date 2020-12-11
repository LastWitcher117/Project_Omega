using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int snackpoints = 0;
    public bool tenScore = false;

    public bool hasKey = false;
    public bool KeyIconImage = false;
    public GameObject KeyIcon;
    public GameObject KeyGetter;
    public bool SignalFromTrigger;

    public float MS;
    public float SpeedDauer = 2f;
    public float SpeedStrengh = 0.5f;
    public bool MSUP = false;

    public GameObject MSUP_Screen;

    public ThirdPersonMovement TPM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (snackpoints == 100 && tenScore == false)
        {

            float angle = -90f;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.right);    //Für richitge Positionierung der VFX von YAY 10

            tenScore = true;
            FindObjectOfType<AudioManager>().Play("10ScorePoints");
            Debug.Log("10 Punkte YAY");

        }


        SignalFromTrigger = FindObjectOfType<GetKey>().EnterSignal;

        if (SignalFromTrigger == true)
        {
            hasKey = true;
            KeyIconImage = GameObject.Find("Canvas (Snackpoints)").GetComponent<Image>();

            KeyIcon.SetActive(true);

        }

        MS = FindObjectOfType<ThirdPersonMovement>().speed;

        if (MSUP == true)
        {
            MSUP_Screen.SetActive(true);
            FindObjectOfType<AudioManager>().Play("MSUP");
            TPM.speed = MS + SpeedStrengh;

            StartCoroutine(Waiter());

        }

    }

    IEnumerator Waiter()
    {

        MSUP = false;
        yield return new WaitForSeconds(SpeedDauer);
        MSUP_Screen.SetActive(false);
        TPM.speed = MS - SpeedStrengh;
    }

}
