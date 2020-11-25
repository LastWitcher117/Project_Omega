using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horitontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horitontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f) //magnitude is the length of the direction vector
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //ROTATION//get the anggle in the klick and view direction
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //ROTATION//smooth the rotation by directionchange
            transform.rotation = Quaternion.Euler(0f, angle, 0f); //ROTATION//rotate the character in the right direction by using angle

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f )*Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime); //moveFunktion

        }
    }
}
