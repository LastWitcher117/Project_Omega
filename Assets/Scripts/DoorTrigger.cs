using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public GameObject Door;
    public GameObject KeyIcon;
    public bool hasKey;

    // Update is called once per frame

    private void Update()
    {

        hasKey = FindObjectOfType<GameManagerScript>().hasKey;

    }

    private void OnTriggerEnter(Collider other)
    {
       

        if(hasKey == true)
        {
            Door.SetActive(false);
            KeyIcon.SetActive(false);
        }
    }
}
