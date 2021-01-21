using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{

    string FMOD_Event_Path = "event:/Music/Music_Main";
    public FMOD.Studio.EventInstance Music_Event_Instance;

    GameObject[] Enemies;
    int EnemyFollowingCount = 0;
    int GuardianFollowingCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Music_Event_Instance = FMODUnity.RuntimeManager.CreateInstance(FMOD_Event_Path);
        Music_Event_Instance.start();

        Enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollowingCount = 0;
        GuardianFollowingCount = 0;
        Music_Event_Instance.setParameterByName("MusicState", 0);

        foreach (GameObject ghost in Enemies)
        {
            // EnemyFollowingCount = EnemyFollowingCount + ghost.GetComponent<EnemyController>().FollowingPlayer;
            // Debug.Log(ghost.GetComponent<EnemyController>().FollowingPlayer.ToString());

            try
            {
                EnemyFollowingCount = EnemyFollowingCount + ghost.GetComponent<EnemyController>().FollowingPlayer;
                GuardianFollowingCount = GuardianFollowingCount + ghost.GetComponent<GuardianPatrol>().FollowingPlayer;

                // Debug.Log(ghost.GetComponent<EnemyController>().FollowingPlayer.ToString());
            }
            catch (System.NullReferenceException exception)
            {
                // Debug.LogError("Oops, no EnemyController attached to this enemy.", this);
            }
        }

        if ((EnemyFollowingCount + GuardianFollowingCount) != 0)
        {
            Debug.Log("Enemies following: " + (EnemyFollowingCount + GuardianFollowingCount).ToString());
            Music_Event_Instance.setParameterByName("MusicState", 1);
        }


    }
}
