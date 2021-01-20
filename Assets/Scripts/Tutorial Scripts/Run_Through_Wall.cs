using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Through_Wall : MonoBehaviour
{
    public GameObject Escape;

    public Pause_Menu PM;

    private void OnTriggerEnter(Collider other)
    {
        Escape.SetActive(true);
        Time.timeScale = 0f;
        PM.isPause = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Space) && Escape == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            Escape.SetActive(false);
            PM.isPause = false;

            gameObject.SetActive(false);

        }

    }
}
