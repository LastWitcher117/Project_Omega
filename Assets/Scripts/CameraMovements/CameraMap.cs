using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour
{

    public GameObject vcam;
    public GameObject MainCamera;
    public GameObject CamOnTower;


    private void OnTriggerEnter(Collider other)
    {
        vcam.SetActive(true);
        MainCamera.SetActive(false);
        CamOnTower.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        vcam.SetActive(false);
        CamOnTower.SetActive(true);
    }
}
