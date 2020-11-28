using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_Scene : MonoBehaviour
{
    public Canvas You_Win_Screen;

    public int nextSceneToLoad;

    IEnumerator OnTriggerEnter(Collider other)
    {
        You_Win_Screen.enabled = true;
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 2.5f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }
}
