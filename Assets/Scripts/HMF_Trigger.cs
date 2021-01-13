using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMF_Trigger : MonoBehaviour
    {public Canvas HDMI;
    public void OnTriggerEnter(){
        if (tag == "HMF"){
            Debug.Log("KURWA");
            HDMI.enabled = true;
            if (tag == "Untagged"){
                Debug.Log("SPIERDALAMY");
                HDMI.enabled = false;}}}
    void OnTriggerExit(){
        if (tag == "HMF"){
            Debug.Log("SPIERDALAMY");
            HDMI.enabled = false;} }}
        
   


