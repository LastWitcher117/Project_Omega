using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootStepsSound : MonoBehaviour
{
    public void PlayrFSRight()
    {
        //footStepsSounds.setParameterByName("Waiting-Moving-Dash", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Waiting-Moving-Dash", 1);
    }

    public void PlayrFSLeft()
    {
        // footStepsSounds.setParameterByName("Waiting-Moving-Dash", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Waiting-Moving-Dash", 0);
    }
}
