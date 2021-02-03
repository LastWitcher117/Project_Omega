using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUPLooker : MonoBehaviour
{ 
    public GameObject MC;
    public GameObject AtTowerLooker;
    public TowerDownCamera TDC;

    private void OnTriggerEnter(Collider other)
    {
        TDC.WasOnTop = true;
    }

}
