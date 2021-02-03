using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDownCamera : MonoBehaviour
{
    public GameObject MC;
    public GameObject AtTowerLooker;

    public bool WasOnTop = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
                if (WasOnTop == false)
                {
                    MC.SetActive(false);
                    AtTowerLooker.SetActive(true);
                }

               
               if(WasOnTop == true)
               {

                   AtTowerLooker.SetActive(false);
                   MC.SetActive(true);

               }
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if(WasOnTop == true)
            {
               WasOnTop = false;
            }
        }
    }
}

