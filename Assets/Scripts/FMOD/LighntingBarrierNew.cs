using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighntingBarrierNew : MonoBehaviour
{

    public Rigidbody rb;

    FMOD.Studio.EventInstance ElectricBarrier2;
    private void Start()
    {
        ElectricBarrier2 = FMODUnity.RuntimeManager.CreateInstance("event:/Enviroment/ElectricBarrier2");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(ElectricBarrier2, transform, GetComponent<Rigidbody>());

        ElectricBarrier2.start();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ElectricBarrier2.setParameterByName("Power", 1f);
        }
    }

}
