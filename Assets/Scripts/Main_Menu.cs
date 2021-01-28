using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    
    FMOD.Studio.EventInstance hovering;
    private FMOD.Studio.PLAYBACK_STATE hState;

    public GameObject GetIntoPlayOption;
    public GameObject Back_Button;

    private void Start()
    {
        hovering = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Hovering");
    }

    public void PlayGameWithTutorial()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); //new line

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayGameNormal()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); //new line

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //Stoppe Main Music 
    }

    public void GetIntoPlayOptions()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line

        GetIntoPlayOption.SetActive(true);
    }

    public void GetOutPlayOptions()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line

        Back_Button.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        Application.Quit();
    }

    public void UiButtonHovering()
    {
        hovering.getPlaybackState(out hState);
        if (hState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            hovering.start();
        }
    }
}
