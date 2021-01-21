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
        PM.isPause = true;
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
            Escape.SetActive(false);
            PM.isPause = false;

            gameObject.SetActive(false);

        }
        
    }
}
