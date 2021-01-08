using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour
{
    ThirdPersonMovement moveScript;

    public float dashSpeed;
    public float dashTime;
    public float cooldownTime = 2;
    public float nextDashTime = 0f;
    bool isDash = false;

    public CharacterController controller;

    public AnimationController re;

    public bool GetIsDash()
    {
        return this.isDash;

    }

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
            if (Input.GetKey(KeyCode.LeftShift)) //Input Leftclick höhö
            {
                re.isDashing = true;

                StartCoroutine(DashAnimationWaiter());

                if (Time.timeScale > 0f)
                {
                     
                    StartCoroutine(Dash());
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Footsteps/DashOneShot");
                    //FindObjectOfType<AudioManager>().Play("Player Dash");
                    //FMOD
                    isDash = true;
                    nextDashTime = Time.time + cooldownTime;
                    
                }
               

            }
       
        }

         if(Time.time < nextDashTime)
         {
             isDash = false;
         }
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;              
            while (Time.time < startTime + dashTime) //Dash movement 
            {
                moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            isDash = true;
            yield return null;
            
            }
       
    }

    IEnumerator DashAnimationWaiter()
    {
        yield return new WaitForSeconds(0.75f);
        re.isDashing = false;
    }

                
    
}