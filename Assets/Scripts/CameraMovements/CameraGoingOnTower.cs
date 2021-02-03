using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGoingOnTower : MonoBehaviour
{
    public bool GoingUP = false;

    public GameObject ThirdPersonCamera;
    public GameObject TowerCamera;

    public Teleport TP;

    public bool TPNoDMG = false;

    private void OnTriggerEnter(Collider other)
    {
        GoingUP = true;
        TPNoDMG = true;
    }

    private void Update()
    {
        if(GoingUP == true && TP.isOnDestinationUP == true)
        {
            ThirdPersonCamera.SetActive(false);
            TowerCamera.SetActive(true);
            GoingUP = false;
            TP.isOnDestinationUP = false;
            TPNoDMG = false;
        }
    }

}
