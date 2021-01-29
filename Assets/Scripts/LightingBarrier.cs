using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBarrier : MonoBehaviour
{
    public GameObject Lightning;
    public GameObject LightningDamageDealer;

    public DoorTrigger DT;
    public Health HP;

    public GameObject Dmg_Flashscreen;

    // Update is called once per frame
    void Update()
    {
        if(DT.hasKey == true)
        {
            Lightning.SetActive(false);
            LightningDamageDealer.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        HP.health--;


        Dmg_Flashscreen.SetActive(true);
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);

    }

}
