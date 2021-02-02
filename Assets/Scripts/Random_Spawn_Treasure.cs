using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Spawn_Treasure : MonoBehaviour
{
    public GameObject T1;
    public GameObject T2;
    public GameObject T3;
    public GameObject T4;

    public GameObject Coins1;
    public GameObject Coins2;
    public GameObject Coins3;
    public GameObject Coins4;

    public float spawnLocation;

    public GameManagerScript gms;

    void Start()
    {
        spawnLocation = Random.Range(1, 5);
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
        if (gms.hasCollectedTreasure == true)
        {
            Coins1.SetActive(false);
            Coins2.SetActive(false);
            Coins3.SetActive(false);
            Coins4.SetActive(false);
        }
    }
}
