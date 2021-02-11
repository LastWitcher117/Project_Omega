using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerCameraController : MonoBehaviour
{
    public GameObject ThirdPersonCamera;

    public GameObject Lower_Perspective;
    public GameObject Zoom_Out;
    public GameObject Top_Down;
    public GameObject Top_Down2;
    public GameObject ThirdPersonStatic;
    public GameObject GhostCam;
    public GameObject GhostMaskCam;
    public GameObject SnakeCam;

    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {
            ThirdPersonCamera.SetActive(true);
            Lower_Perspective.SetActive(false);
            Zoom_Out.SetActive(false);
            Top_Down.SetActive(false);
            Top_Down2.SetActive(false);
            ThirdPersonStatic.SetActive(false);
            GhostCam.SetActive(false);
            SnakeCam.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ThirdPersonCamera.SetActive(false);
            Lower_Perspective.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ThirdPersonCamera.SetActive(false);
            Zoom_Out.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ThirdPersonCamera.SetActive(false);
            Top_Down.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ThirdPersonCamera.SetActive(false);
            Top_Down2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ThirdPersonCamera.SetActive(false);
            ThirdPersonStatic.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            ThirdPersonCamera.SetActive(false);
            GhostCam.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            ThirdPersonCamera.SetActive(false);
            GhostMaskCam.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            ThirdPersonCamera.SetActive(false);
            SnakeCam.SetActive(true);
        }

    }
}
