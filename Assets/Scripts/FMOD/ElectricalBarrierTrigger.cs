using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBarrierTrigger : MonoBehaviour
{

    public ElectricalBarrierController EBC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EBC.ActivateEB3a = true;
        }
    }

}
