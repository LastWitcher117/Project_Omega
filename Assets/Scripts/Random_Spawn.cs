using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Spawn : MonoBehaviour
{
    public Vector3[] positions;

    public GameObject way1;
    public GameObject way2;
    public GameObject way3;
    public GameObject way4;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;

    public GameObject KeyEffect1;
    public GameObject KeyEffect2;
    public GameObject KeyEffect3;
    public GameObject KeyEffect4;

    public float spawnLocation;

    public GameManagerScript gms;


    void Start()
    {
        spawnLocation = Random.Range(1, 5);
        Debug.Log(spawnLocation);

        if(spawnLocation == 1)
        {
            key1.SetActive(true);
            KeyEffect1.SetActive(true);
        }
        if (spawnLocation == 2)
        {
            key2.SetActive(true);
            KeyEffect2.SetActive(true);
        }
        if (spawnLocation == 3)
        {
            key3.SetActive(true);
            KeyEffect3.SetActive(true);
        }
        if (spawnLocation == 4)
        {
            key4.SetActive(true);
            KeyEffect4.SetActive(true);
        }
        //transform.position = positions[Random.Range(0, positions.Length)];
        //transform.position = positions(481.67, 1.669998, 189.55);
    }

    void Update()
    {
        if (spawnLocation == 1 && gms.hasKey == true)
        {
            way1.SetActive(true);
        }
        if (spawnLocation == 2 && gms.hasKey == true)
        {
            way2.SetActive(true);
        }
        if (spawnLocation == 3 && gms.hasKey == true)
        {
            way3.SetActive(true);
        }
        if (spawnLocation == 4 && gms.hasKey == true)
        {
            way4.SetActive(true);
        }

/*/-----------------------------------------------------------------------------------------/*/

       
    }
}
