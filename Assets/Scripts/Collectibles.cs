using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameManagerScript gms;


    void OnTriggerEnter(Collider other)
    {
   
        if (other.tag == "MSUP")
        {
   
            gms.MSUP = true;
            Destroy(other.gameObject);
        }
    }

}
