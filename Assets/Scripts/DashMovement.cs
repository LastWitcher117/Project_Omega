﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    public float dashSpeed;
    public float dashTime;
    public float cooldownTime = 2;
    public float nextDashTime = 0f;

    public CharacterController controller;
    

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Time.time > nextDashTime)
        {
            if (Input.GetMouseButtonDown(0)) //Input Leftclick höhö
            {
                StartCoroutine(Dash());
                nextDashTime = Time.time + cooldownTime;               
            }
        }
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;              
            while (Time.time < startTime + dashTime) //Dash movement 
            {
                moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
                yield return null;
                
            }       
    }
}