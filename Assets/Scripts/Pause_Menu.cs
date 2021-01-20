using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public bool isPause = false;

    public AudioSource ButtonClick;

    //FMOD
    FMOD.Studio.EventInstance fVolumeSlider;
    FMOD.Studio.EventInstance hovering;
    private FMOD.Studio.PLAYBACK_STATE fVState;
    private FMOD.Studio.PLAYBACK_STATE hState;
    public GameObject volumeSlider;

    private void Start()
    {
        fVolumeSlider = FMODUnity.RuntimeManager.CreateInstance("event:/UI/VolumeSlider");
        hovering = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Hovering");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            Cursor.lockState = CursorLockMode.None;
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                isPause = true;
            }
        }
    }

    public void ButtonSound()
    {
        ButtonClick.Play();
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        //AudioListener.pause = false;
        GameIsPaused = false;
        isPause = false;
        FindObjectOfType<AudioManager>().Play("Theme");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //AudioListener.pause = true;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Pause("Theme");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 0); // new line
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("WinSound");
        SceneManager.LoadScene(0);

        StartCoroutine(GamePauseParameterFMod());
    }

    void Options()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //AudioListener.pause = true;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Pause("Theme");
    }

    public void SetVolume(float volume)
    {
        
        FVolumeSlider(volume);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("MASTER VOLUME", volume);  // FMOD
    }

    // FMOD
    public void UiButtonSoundForward()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
    }

    public void UiButtonSoundBackward()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
    }

    public void UiButtonHovering()
    {
        hovering.getPlaybackState(out hState);
        if (hState!= FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            hovering.start();
        }
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

    IEnumerator GamePauseParameterFMod() 
    {
        yield return new WaitForSeconds(0.5f);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);  // FMOD
    }
}
