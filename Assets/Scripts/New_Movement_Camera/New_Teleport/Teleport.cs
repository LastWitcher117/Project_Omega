using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; //Teleport Position
    public GameObject player; // Teleporting player

    public CameraGoingOnTower CameraUP;
    public CameraGoingAwayTower CameraDOWN;

    public bool isOnDestinationUP = false;
    public bool isOnDestinationDown = false;

    private void OnTriggerEnter(Collider other) // Setting trigger for teleport
    {
        if (other.tag == "Player")
        {
            if (CameraDOWN.GoingDown == true)
            {
                StartCoroutine(TPWaiterDown());
            }

            if (CameraUP.GoingUP == true)
            {
               
                StartCoroutine(TPWaiterUP());
                
            }
        }
    }

    IEnumerator TPWaiterUP()
    {
        isOnDestinationUP = true;
        yield return new WaitForSeconds(2f);
        player.transform.position = teleportTarget.transform.position; // Trigger makes one position equal to another
        
       
    }

    IEnumerator TPWaiterDown()
    {
        player.transform.position = teleportTarget.transform.position; // Trigger makes one position equal to another
        yield return new WaitForSeconds(0.01f);
        isOnDestinationDown = true;

    }

}
