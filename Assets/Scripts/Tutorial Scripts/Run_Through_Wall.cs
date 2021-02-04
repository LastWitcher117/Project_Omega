using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_Through_Wall : MonoBehaviour
{
    public GameObject Escape;

    public Pause_Menu PM;
    public bool InsideCollider = false;

    private void OnTriggerEnter(Collider other)
    {
        Escape.SetActive(true);
        Time.timeScale = 0f;
        PM.enabled = false;
        InsideCollider = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    void Start()
    {
        Escape.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && InsideCollider == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
            Escape.SetActive(false);
            PM.enabled = true;

            gameObject.SetActive(false);

        }
        
    }
}
