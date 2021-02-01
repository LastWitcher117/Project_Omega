using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; //Teleport Position
    public GameObject player; // Teleporting player

    void OnTriggerEnter(Collider other) // Setting trigger for teleport
    {
        player.transform.position = teleportTarget.transform.position; // Trigger makes one position equal to another
    }
}
