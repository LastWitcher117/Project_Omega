using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerTutorial : MonoBehaviour
{
    public GameObject Door;
    public GameObject KeyIcon;
    public bool hasKey;
    bool doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(hasKey == true)
        {
            Door.SetActive(false);
            KeyIcon.SetActive(false);

            if (doorOpen == false)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/Door");
            }
            doorOpen = true;
        }
    }
}
