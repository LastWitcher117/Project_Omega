﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation_Fire_Script : MonoBehaviour
{

   public GameObject VFX_Fire;

    public bool onTower;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            VFX_Fire.SetActive(true);
            onTower = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        onTower = false;
    }

}
