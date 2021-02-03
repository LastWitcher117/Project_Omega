using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGoingAwayTower : MonoBehaviour
{
    public bool GoingDown = false;
    public bool GoDownNow = false;

    public GameObject ThirdPersonCamera;
    public GameObject TowerCamera;

    public Teleport TP;

    private void OnTriggerEnter(Collider other)
    {
        GoingDown = true;
        
    }

    private void Update()
    {
        if (GoingDown == true && TP.isOnDestinationDown == true)
        {
            TowerCamera.SetActive(false);
            ThirdPersonCamera.SetActive(true);           
            GoingDown = false;
            TP.isOnDestinationDown = false;

        }
    }

}
