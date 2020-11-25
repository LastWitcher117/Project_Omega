using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    public float dashSpeed;
    public float dashTime;
    public CharacterController controller;
    public bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<ThirdPersonMovement>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Input Leftclick höhö
        {
            
            StartCoroutine(Dash());          
            
            if (isDashing == true)
            {
                StartCoroutine(Timer());
            }
        }
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;
        if (isDashing == false)
        {         
            while (Time.time < startTime + dashTime) //Dash movement 
            {
                moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
                isDashing = true;
                yield return null;
                
            }
        }
        
    }

    IEnumerator Timer() //Couldown timer
    {    
        yield return new WaitForSeconds(4.0f);
        isDashing = false;
    }

}