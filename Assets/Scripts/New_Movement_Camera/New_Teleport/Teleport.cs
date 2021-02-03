using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; //Teleport Position
    public GameObject player; // Teleporting player

    public TowerDownCamera TDC;
    public TowerUPLooker TUL;
    public AnimationController AC;

    void OnTriggerEnter(Collider other) // Setting trigger for teleport
    {
        if (other.tag == "Player")
        {
            if (TUL.isUP == false)
            {
                StartCoroutine(TPWaiterUP());
            }

            if (TUL.isUP == true)
            {
                StartCoroutine(TPWaiterDown());
            }
        }
    }

    IEnumerator TPWaiterUP()
    {
        
        yield return new WaitForSeconds(2f);
        player.transform.position = teleportTarget.transform.position; // Trigger makes one position equal to another
        AC.inTutorial = false;
    }

    IEnumerator TPWaiterDown()
    {
        player.transform.position = teleportTarget.transform.position; // Trigger makes one position equal to another
        yield return new WaitForSeconds(0.01f);
        TUL.isUP = false;

    }

}
