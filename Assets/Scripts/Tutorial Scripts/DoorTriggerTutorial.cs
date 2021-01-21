﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerTutorial : MonoBehaviour
{
    public GameObject Door;
    public GameObject KeyIcon;

    public GameObject GoodJobKey;
    public GameObject YouNeedKey;

    public AnimationController AC;

    public bool hasKey;
    public bool FirstTime;

    bool doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(hasKey == true && FirstTime == false)
        {
            Door.SetActive(false);
            KeyIcon.SetActive(false);

            if (doorOpen == false)
            {
                GoodJobKey.gameObject.SetActive(true);
                AC.inTutorial = true;

                FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/Door");

                

            }

            doorOpen = true;
            FirstTime = true;
        }
        else
        {
            YouNeedKey.gameObject.SetActive(true);
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
                AC.inTutorial = false;

            }
        }

        if(hasKey == false && FirstTime ==true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                YouNeedKey.gameObject.SetActive(false);
                AC.inTutorial = false;
            }
        }
    }

}