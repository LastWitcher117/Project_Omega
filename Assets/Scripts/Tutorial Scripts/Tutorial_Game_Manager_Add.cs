using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Game_Manager_Add : MonoBehaviour
{
    public GameObject TutorialZoom;

    public GameObject TutorialHP;
    public GameObject PressAnyKey_Text;

    public GameManagerScript gms;

    public Health HealthComponent;
    public bool FirstTimeHP = false;

    public Pause_Menu PM;

    public AnimationController AC;

    void Start()
    {
        HealthComponent.health = HealthComponent.health - 1;

       
        AC.inTutorial = true;
       // PM.isPause = false;

    }

    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {

            Time.timeScale = 1f;
            TutorialZoom.gameObject.SetActive(false);
            //PM.isPause = false;
            AC.inTutorial = false;
           
        }

        if (gms.HealthTutorial == true && FirstTimeHP == false)
        {
            TutorialHP.gameObject.SetActive(true);
            Time.timeScale = 0f;

            PressAnyKey_Text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                gms.HealthTutorial = false;
                TutorialHP.gameObject.SetActive(false);
                FirstTimeHP = true;
            }
                    
        }
    }
}
