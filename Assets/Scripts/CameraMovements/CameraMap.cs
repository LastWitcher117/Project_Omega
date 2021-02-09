using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMap : MonoBehaviour
{

    public GameObject vcam;
    public GameObject MainCamera;
    public GameObject CamOnTower;
    public GameObject WASDToGetOut;


    private void OnTriggerEnter(Collider other)
    {
        WASDToGetOut.SetActive(true);
        vcam.SetActive(true);
        MainCamera.SetActive(false);
        CamOnTower.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        WASDToGetOut.SetActive(false);
        vcam.SetActive(false);
        CamOnTower.SetActive(true);
    }
}
