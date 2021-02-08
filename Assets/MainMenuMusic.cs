using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{

    string FMOD_Event_Path_Menu_Music = "event:/Music/Music_Menu";
    public FMOD.Studio.EventInstance Menu_Music_Event_Instance;

    void Start()
    {

        Menu_Music_Event_Instance = FMODUnity.RuntimeManager.CreateInstance(FMOD_Event_Path_Menu_Music);
        Menu_Music_Event_Instance.start();

        
    }


    void Update()
    {
        //if player goes credits dann das 
        //Menu_Music_Event_Instance.setParameterByName("Menu_Music_State", 1);

        //Wenn palyer zurükc ins main menu geht auf 0 setzen 
    }
}
