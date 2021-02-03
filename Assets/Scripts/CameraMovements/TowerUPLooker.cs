using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUPLooker : MonoBehaviour
{ 
    public GameObject MC;
    public GameObject AtTowerLooker;
    public TowerDownCamera TDC;
    public Teleport TP;

    public bool isTeleporting = false;
    public bool isUP = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isUP = true;
        }
    }

    private void Update()
    {
        if (isUP == false)
        {
            StartCoroutine(Waiter());
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2f);
        AtTowerLooker.SetActive(false);
        MC.SetActive(true);
    }

}
