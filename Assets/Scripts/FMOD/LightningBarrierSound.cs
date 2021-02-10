using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LightningBarrierSound : MonoBehaviour
{

    public DoorTrigger DT;

   

    public Rigidbody Laurent;
    

    public bool GoOffSound;

    FMOD.Studio.EventInstance electricBarrier;

   
    void Start()
    {
        electricBarrier = FMODUnity.RuntimeManager.CreateInstance("event:/Enviroment/ElectricBarrier");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(electricBarrier, transform, GetComponent<Rigidbody>());

        //Laurent = GetComponent<Rigidbody>();

       

        //FMODUnity.RuntimeManager.AttachInstanceToGameObject(electricBarrier, transform, Laurent);
        electricBarrier.start();

       //FMODUnity.RuntimeManager.PlayOneShot("event:/Enviroment/ElectricBarrier", GetComponent<Transform>().position);
    }

    private void Update()
    {

         if(GoOffSound == true)
         {
             electricBarrier.setParameterByName("StopLighting", 1f);
         }
        
    }
}
