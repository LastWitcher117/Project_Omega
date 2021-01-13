using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : PortalTraveller
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

    public AnimationController re;

    //Fmod
    [FMODUnity.EventRef]
    public string eventPath;
    FMOD.Studio.EventInstance footStepsSounds;
    DashMovement isDashScript;
    
    float h;
    float v;
    bool isDashBool;

    // Teleport
    public float yaw;
    public float pitch;
    float smoothYaw;
    float smoothPitch;
    Vector3 velocity;

    public Canvas YouWinScreenHere;

    //public Health HealthScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        footStepsSounds = FMODUnity.RuntimeManager.CreateInstance(eventPath);
        footStepsSounds.start();
        isDashScript = GetComponent<DashMovement>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool dash = Input.GetKey(KeyCode.LeftShift);
        
        //FMOD
        h = horizontal;
        v = vertical;
        isDashBool = dash;  

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
    

        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            nextWalkingEffect = Time.time + walkingEffectCouldown;

            re.isWalking = true;

        }
        else
        {
            re.isWalking = false;
        }

        PlayerFootSteps();
        EnableWinScreenKey();


    }

    void CreateDust()
    {
        Instantiate(dust, transform.forward, transform.rotation);
        Debug.Log("u mad gay");
    }

    //FMOD  
     void PlayerFootSteps()
    {
        if (isDashBool == true)
        {
            footStepsSounds.setParameterByName("Waiting-Moving-Dash", 2);
        }
        else if (v < 0 || h < 0 && isDashBool == false)
        {
            footStepsSounds.setParameterByName("Waiting-Moving-Dash", 1);
        }
    
        else if (v > 0 || h > 0 && isDashBool == false)
        {
            footStepsSounds.setParameterByName("Waiting-Moving-Dash", 1);
        }

        else if (v == 0 || h == 0 && isDashBool == false)
        {
            footStepsSounds.setParameterByName("Waiting-Moving-Dash", 0);
        }
    } 

    public void PlayerFootStepsVolume(float enemyDistance)
    {
        float xxx;
        if (enemyDistance <= 20)
        {
            xxx = enemyDistance;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyDistanceVolumeController", xxx);
        }
    }

    public override void Teleport(Transform fromPortal, Transform toPortal, Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        Vector3 eulerRot = rot.eulerAngles;
        float delta = Mathf.DeltaAngle(smoothYaw, eulerRot.y);
        yaw += delta;
        smoothYaw += delta;
        transform.eulerAngles = Vector3.up * smoothYaw;
        velocity = toPortal.TransformVector(fromPortal.InverseTransformVector(velocity));
        Physics.SyncTransforms();
    }

    public void EnableWinScreenKey()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            YouWinScreenHere.enabled = true;

        }
        if (Input.GetKey(KeyCode.F2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            YouWinScreenHere.enabled = false;
            Time.timeScale = 1f;
        }
    }

    /*public void PlayrFSRight()
    {
        footStepsSounds.setParameterByName("Waiting-Moving-Dash", 1);
    }

    public void PlayrFSLeft()
    {
        footStepsSounds.setParameterByName("Waiting-Moving-Dash", 0);
    }*/


}

    

