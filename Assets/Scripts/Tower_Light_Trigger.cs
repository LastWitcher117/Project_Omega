using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Light_Trigger : MonoBehaviour
{
    public ParticleSystem BonFire;

    public void Start()
    {
        BonFire.Stop();
        BonFire.Clear();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("KURWA");
            BonFire.Play();
        }
    }
}
