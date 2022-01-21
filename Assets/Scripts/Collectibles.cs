using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [HideInInspector]
    public GameManagerScript gms;

    private void Start()
    {
        gms = FindObjectOfType<GameManagerScript>();
    }

    void OnTriggerEnter(Collider other)
    {
   
        if (other.tag == "MSUP")
        {
   
            gms.MSUP = true;
            Destroy(other.gameObject);
        }
    }

}
