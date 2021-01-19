using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyfromTutorial : MonoBehaviour
{
    public GameObject ExitWay;
    public GameObject KeyIcon;

    public MeshRenderer KeyMesh;
    public Collider KeyCollider;

    public bool hasKeyTutorial = false;
    public bool EnterSignal = false;

    public GameManagerScript gms;

    public DoorTriggerTutorial DTT;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            KeyIcon.SetActive(true);

            EnterSignal = true;

            ExitWay.SetActive(true);
            hasKeyTutorial = true;

            DTT.hasKey = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            KeyMesh.gameObject.SetActive(false);
            KeyCollider.gameObject.SetActive(false);

        }

    }
}
