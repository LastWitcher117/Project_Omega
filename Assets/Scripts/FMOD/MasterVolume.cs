using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour
{
    public void SetVolume(float volume)
    {

        //FVolumeSlider(volume);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MASTER VOLUME", volume);  
    }
}
