using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyfromTutorial : MonoBehaviour
{
    public GameObject ExitWay;
    public GameObject KeyIcon;

    public GameObject KeyParticleSystem;
    public GameObject GetKeyParticleSystem;

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


            KeyMesh.enabled = false;
            KeyCollider.enabled = false;

            KeyParticleSystem.SetActive(false);
            GetKeyParticleSystem.SetActive(true);

            //StartCoroutine(ParticleWaiter());


        }

    }

    IEnumerator ParticleWaiter()
    {
        yield return new WaitForSeconds(1.5f);
        GetKeyParticleSystem.SetActive(false);
    }

}
