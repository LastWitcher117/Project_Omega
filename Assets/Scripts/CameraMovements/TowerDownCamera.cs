using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDownCamera : MonoBehaviour
{
    public GameObject MC;
    public GameObject AtTowerLooker;

    public TowerUPLooker TUL;

    public bool WasOnTop = false;

    public bool isTeleporting = false;

    public AnimationController AC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AtTowerLooker.SetActive(true);
            MC.SetActive(false);
               
               WasOnTop = true;
              TUL.isUP = true;
                AC.inTutorial = true;
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
    }
}

