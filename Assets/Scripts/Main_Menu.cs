using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        FindObjectOfType<AudioManager>().Play("Theme");

        //FindObjectOfType<AudioManager>().Play("ButtonSounds");

        

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        //FindObjectOfType<AudioManager>().Play("ButtonSounds");
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        Application.Quit();
    }

    public void UiButtonHovering()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Hovering");
    } 
}
