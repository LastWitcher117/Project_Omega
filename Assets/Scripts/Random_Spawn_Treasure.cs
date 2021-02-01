using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Spawn_Treasure : MonoBehaviour
{
    public GameObject T1;
    public GameObject T2;
    public GameObject T3;
    public GameObject T4;

    public float spawnLocation;

    public GameManagerScript gms;

    void Start()
    {
        spawnLocation = Random.Range(1, 4);
        Debug.Log(spawnLocation);
        
        if (spawnLocation == 1)
        {
            T1.SetActive(true);
        }
        if (spawnLocation == 2)
        {
            T2.SetActive(true);
        }
        if (spawnLocation == 3)
        {
            T3.SetActive(true);
        }
        if (spawnLocation == 4)
        {
            T4.SetActive(true);
        }
    }

    void Update()
    {
       
    }
}
