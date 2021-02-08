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
    public GameObject MSUP_Player;

    public ThirdPersonMovement TPM;

    public bool gameIsWon;

    public int PointsNeededForHealth;
    public int HowManyPointsForHP;

    public bool HPUpdate = false;

    public Health HealthComponent;
    public bool HealthTutorial = false;

    public GetTreasure GT;
    public bool hasCollectedTreasure = false;

    public GameObject AmbienceLoop;
    public bool isAmbiencing = false;

    public bool TutorialWeapon = false;

    public Pause_Menu PM;

    public TimerCountdown TC;

    // Start is called before the first frame update
    void Start()
    {
        PM.enabled = true;
        gameIsWon = false;
        TC.PlayerWon = false;
        Health HealthComponent = GetComponent<Health>();
        //isAmbiencing = true;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAmbiencing == true)
        {
            isAmbiencing = false;
            StartCoroutine(AmbienceLoopWaiter());
        }


        if (HPUpdate == true)
        {
            HowManyPointsForHP = PointsNeededForHealth;
        }

        if (snackpoints == 100 && tenScore == false)
        {

            float angle = -90f;
            transform.rotation *= Quaternion.AngleAxis(angle, Vector3.right);    //Für richitge Positionierung der VFX von YAY 10

            tenScore = true;
            //FindObjectOfType<AudioManager>().Play("10ScorePoints");
            
            Debug.Log("10 Punkte YAY");

        }

        if (GT.CollectedTreasure == true)
        {
            PointsNeededForHealth = PointsNeededForHealth + 1000;
            hasCollectedTreasure = true;
            GT.CollectedTreasure = false;
        }

        if (PointsNeededForHealth == snackpoints)
        {
           
            PointsNeededForHealth = PointsNeededForHealth + HowManyPointsForHP;

            Debug.Log(PointsNeededForHealth);

            if(HealthComponent.health < 3)
            {
                HealthComponent.health = HealthComponent.health + 1;
                HealthTutorial = true;
                Debug.Log(HealthComponent.health);
            }
                                 
        }

        if (SignalFromTrigger == true)
        {
            hasKey = true;
            KeyIconImage = GameObject.Find("Canvas (Snackpoints&Key)").GetComponent<Image>();

            KeyIcon.SetActive(true);

        }

        MS = FindObjectOfType<ThirdPersonMovement>().speed;

        if (MSUP == true)
        {
            MSUP_Screen.SetActive(true);

            MSUP_Player.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/MSUP");
            //FindObjectOfType<AudioManager>().Play("MSUP");
            TPM.speed = MS + SpeedStrengh;

            StartCoroutine(Waiter());

        }

    }

    IEnumerator Waiter()
    {

        MSUP = false;
        yield return new WaitForSeconds(SpeedDauer);
        MSUP_Screen.SetActive(false);
        MSUP_Player.SetActive(false);
        TPM.speed = MS - SpeedStrengh;
    }

    IEnumerator AmbienceLoopWaiter()
    {
        AmbienceLoop.SetActive(true);
        yield return new WaitForSeconds(56f);
        AmbienceLoop.SetActive(false);
        isAmbiencing = true;
    }

}
