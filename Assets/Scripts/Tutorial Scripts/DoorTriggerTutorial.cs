using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerTutorial : MonoBehaviour
{
    public GameObject Door;
    public GameObject KeyIcon;

    public GameObject GoodJobKey;
    public GameObject YouNeedKey;

    public AnimationController AC;

    public Pause_Menu PM;

    public Animator Door1;
    public Animator Door2;

    public bool hasKey;
    public bool FirstTime;

    bool doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(hasKey == true && FirstTime == false)
        {
            //Door.SetActive(false);
            KeyIcon.SetActive(false);

            if (doorOpen == false)
            {
                GoodJobKey.gameObject.SetActive(true);
                AC.inTutorial = true;
                PM.enabled = false;

                FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/Door");

                Door1.SetBool("DoorOpen", true);
                Door2.SetBool("DoorOpen", true);
            }

            doorOpen = true;
            FirstTime = true;
        }
        else
        {
            YouNeedKey.gameObject.SetActive(true);
            PM.enabled = false;

            AC.inTutorial = true;
            FirstTime = true;

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        FirstTime = false;
    }

    public void Update()
    {
        if (hasKey == true && doorOpen ==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GoodJobKey.gameObject.SetActive(false);
                PM.enabled = true;

                AC.inTutorial = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");

            }
        }

        if(hasKey == false && FirstTime ==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                YouNeedKey.gameObject.SetActive(false);
                PM.enabled = true;

                AC.inTutorial = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
            }
        }
    }

}
