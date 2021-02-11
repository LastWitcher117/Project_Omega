using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Light_Trigger : MonoBehaviour
{
    public GameObject BonFire;
    public Pause_Menu PM;

    public GameObject WindEffectOnTower;

  /*  public void Start()
    {
        BonFire.Stop();
        BonFire.Clear();
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PM.enabled = false;
            Debug.Log("KURWA");
            BonFire.SetActive(true);
            WindEffectOnTower.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        WindEffectOnTower.SetActive(false);
        PM.enabled = true;
    }

}
