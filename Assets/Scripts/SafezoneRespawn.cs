using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafezoneRespawn : MonoBehaviour
{
    Vector3 StartPos;
    public GameObject Enemy;

    public void Awake()
    {
        StartPos = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safezone")
        {
            StartCoroutine("RespawnEnemy");
        }
    }

    IEnumerator RespawnEnemy()
    {
        GameObject clone = (GameObject)Instantiate(Enemy, StartPos, Quaternion.identity) as GameObject;
        Destroy(Enemy.gameObject);
        yield return null;
    }
}
