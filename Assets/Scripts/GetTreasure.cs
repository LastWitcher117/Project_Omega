using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    private GameManagerScript gms;

    [HideInInspector]
    [SerializeField] public bool CollectedTreasure;
    public GameObject GetTreasures;

    private void Start()
    {

        gms = FindObjectOfType<GameManagerScript>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Treasure")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Collectables/Treasure");
            gms.snackpoints = gms.snackpoints + 1000;
            CollectedTreasure = true;
            
        }
    }
}
