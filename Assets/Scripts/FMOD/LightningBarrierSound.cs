using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBarrierSound : MonoBehaviour
{

    public DoorTrigger DT;
    public Rigidbody Test;

    public bool GoOffSound;

    FMOD.Studio.EventInstance electricBarrier;

   
    void Start()
    {
        Test = GetComponent<Rigidbody>();

        electricBarrier = FMODUnity.RuntimeManager.CreateInstance("event:/Enviroment/ElectricBarrier");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(electricBarrier, transform, Test);
        electricBarrier.start();

    }

    private void Update()
    {
        if(GoOffSound == true)
        {
            electricBarrier.setParameterByName("StopLighting", 1f);
        }
    }
}
