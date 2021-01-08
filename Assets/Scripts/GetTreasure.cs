using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    public GameManagerScript gms;
  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Treasure")
        {
            gms.snackpoints = gms.snackpoints + 1000;
            FindObjectOfType<AudioManager>().Play("Treasure");
            Destroy(other.gameObject);

       

        }
    }
}
