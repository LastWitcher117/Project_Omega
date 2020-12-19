﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Xml.Linq;

public class Options_Settings : MonoBehaviour
{
    public AudioMixer MainMixer;
    public AudioSource ButtonClick;

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;

    //FMOD
    FMOD.Studio.EventInstance fVolumeSlider;
    private FMOD.Studio.PLAYBACK_STATE fVState;
    public GameObject volumeSlider;

    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fVolumeSlider = FMODUnity.RuntimeManager.CreateInstance("event:/UI/VolumeSlider");
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        FVolumeSlider(volume);
    }

    public void ButtonSound()
    {
        //ButtonClick.Play();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

     public void UiButtonSoundForward()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
    }

    public void UiButtonSoundBackward()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
    }

    void FVolumeSlider(float sliderValue)
    {
        fVolumeSlider.getPlaybackState(out fVState);
        if (fVState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            fVolumeSlider.start();
            fVolumeSlider.setParameterByName("VolumeSlider", sliderValue);
        }
    }
}
