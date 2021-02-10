using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public Animator Door;
    public GameObject KeyIcon;
    public bool hasKey;
    bool doorOpen;

    public GameObject YouNeedKey;
    public GameObject EndFog;

    // Update is called once per frame

    private void Update()
    {

        hasKey = FindObjectOfType<GameManagerScript>().hasKey;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (hasKey == true)
            {
                //doorOpen == false ? FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/Door"): Fake() ;

                if (doorOpen == false)
                {
                    StartCoroutine(Waiter());

                }

                Door.SetBool("DoorOpen", true);
                KeyIcon.SetActive(false);
                EndFog.SetActive(true);
                doorOpen = true;
            }
            else
            {

                YouNeedKey.gameObject.SetActive(true);

            }
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(0.5f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/Door");
    }

    private void OnTriggerExit(Collider other)
    {
        YouNeedKey.gameObject.SetActive(false);
    }

}

  

