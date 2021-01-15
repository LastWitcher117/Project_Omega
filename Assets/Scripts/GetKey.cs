using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetKey : MonoBehaviour
{
    public bool EnterSignal = false;
    public ExitWay EW;

    private void OnTriggerEnter(Collider other)
    {
        EnterSignal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        EnterSignal = false;
        transform.position = transform.position + new Vector3(0f, -10f, 0f);
        EW.Lights.SetActive(true);
    }

    private void Update()
    {
        
    }

}
