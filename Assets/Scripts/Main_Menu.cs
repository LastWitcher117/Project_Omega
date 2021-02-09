using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    
    FMOD.Studio.EventInstance hovering;
    private FMOD.Studio.PLAYBACK_STATE hState;

    public Animator MainMenu;

    public GameObject GetIntoPlayOption;
    public GameObject Back_Button;

    [Header("Main Menu Buttons")]

    public GameObject Title;
    public GameObject PlayButton;
    public GameObject Optionsbutton;
    public GameObject CreditsButton;
    public GameObject QuitButton;
    public GameObject CurseBreakerLogo;

    [Header("Get into Play Menu Buttons")]

    public GameObject Iama;
    public GameObject StartGameNormal;
    public GameObject StartTutorial;
    public GameObject BackButton;

    private void Start()
    {
        hovering = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Hovering");
    }

    public void PlayGameWithTutorial()
    {

        MainMenu.SetBool("WhenGameIsStarted", true);

        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); //new line

        Iama.SetActive(false);
        StartGameNormal.SetActive(false);
        StartTutorial.SetActive(false);
        BackButton.SetActive(false);

        StartCoroutine(TutorialWaiter());
    }

    public void PlayGameNormal()
    {
        MainMenu.SetBool("WhenGameIsStarted", true);

        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); //new line


        Iama.SetActive(false);
        StartGameNormal.SetActive(false);
        StartTutorial.SetActive(false);
        BackButton.SetActive(false);

        StartCoroutine(NormalWaiter());

        //Stoppe Main Music 
    }

    public void GetIntoPlayOptions()
    {

        Title.SetActive(false);
        PlayButton.SetActive(false);
        Optionsbutton.SetActive(false);
        CreditsButton.SetActive(false);
        QuitButton.SetActive(false);
        CurseBreakerLogo.SetActive(false);

        MainMenu.SetBool("WhenPlayIsPressed", true);

        //FMOD
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Backward");
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GamePaused", 1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1); // new line
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("EnemyGroupVolumeController", 1); // new line

        GetIntoPlayOption.SetActive(true);
    }

    public void GetOutPlayOptions()
    {

        Title.SetActive(true);
        PlayButton.SetActive(true);
        Optionsbutton.SetActive(true);
        CreditsButton.SetActive(true);
        QuitButton.SetActive(true);
        CurseBreakerLogo.SetActive(true);

        MainMenu.SetBool("WhenPlayIsPressed", false);

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

    IEnumerator TutorialWaiter()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    IEnumerator NormalWaiter()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
