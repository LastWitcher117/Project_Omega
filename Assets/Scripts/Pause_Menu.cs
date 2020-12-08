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
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //AudioListener.pause = true;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Pause("Theme");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
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
        
    }
}
