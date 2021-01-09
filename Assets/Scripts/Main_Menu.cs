using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    
    FMOD.Studio.EventInstance hovering;
    private FMOD.Studio.PLAYBACK_STATE hState;
    

    private void Start()
    {
        hovering = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Hovering");
    }

    public void PlayGame()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
