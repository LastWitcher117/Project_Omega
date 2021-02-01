using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    public bool EnterSignal = false;
    public ExitWay EW;
    public GameManagerScript gms;

    public Random_Spawn rs;

    private void OnTriggerEnter(Collider other)
    {
        EnterSignal = true;
        gms.SignalFromTrigger = true;

        EnterSignal = false;
        transform.position = transform.position + new Vector3(0f, -10f, 0f);
        //EW.Lights.SetActive(true);

        if (rs.spawnLocation == 1)
        {
            rs.way1.SetActive(true);
        }
        if (rs.spawnLocation == 2)
        {
            rs.way2.SetActive(true);
        }
        if (rs.spawnLocation == 3)
        {
            rs.way3.SetActive(true);
        }
        if (rs.spawnLocation == 4)
        {
            rs.way4.SetActive(true);
        }
    }

}
