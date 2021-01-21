using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TEST_Trigger : MonoBehaviour
{

    MusicManager MyMusicManager = GameObject.Find("GameManager").GetComponent<MusicManager>();
    FMOD.Studio.EventInstance MyMusic_Event_Instance = MyMusicManager.Music_Event_Instance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        MyMusic_Event_Instance.setParameterByName("MusicState", 1);
    }
}
