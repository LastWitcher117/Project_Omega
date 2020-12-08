using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Play("Theme");

        FindObjectOfType<AudioManager>().Play("ButtonSounds");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        FindObjectOfType<AudioManager>().Play("ButtonSounds");
        Application.Quit();
    }
}
