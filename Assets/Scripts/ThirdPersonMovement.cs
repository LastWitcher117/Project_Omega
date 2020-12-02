using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    public float nextWalkingEffect = 0f;
    public float walkingEffectCouldown = 1f;

    float turnSmoothVelocity;

    public Vector3 moveDir;

    public GameObject dust;
    public bool isWalkingEffect = true;
   


    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
    

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            nextWalkingEffect = Time.time + walkingEffectCouldown;
         
        }       
    }

    void OnCollisionEnter3D(Collision collision)
    {
        if (collision.rigidbody.tag == "Enemy")
        {
            //Health.
        }
    }


    void CreateDust()
    {
        Instantiate(dust, transform.forward, transform.rotation);
        Debug.Log("u mad gay");
    }

}
