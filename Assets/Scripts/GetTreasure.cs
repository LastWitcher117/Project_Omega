using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    public GameManagerScript gms;

    public ExitWay EW;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Treasure")
        {
            gms.snackpoints = gms.snackpoints + 1000;
            FindObjectOfType<AudioManager>().Play("Treasure");


            EW.Lights.SetActive(true);
            Destroy(other.gameObject);

        }
    }
}
