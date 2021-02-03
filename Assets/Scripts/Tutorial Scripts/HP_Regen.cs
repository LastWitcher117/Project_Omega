using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Regen : MonoBehaviour
{
    public GameObject HPRegen;
    public Pause_Menu PM;

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f;
        HPRegen.gameObject.SetActive(true);
        PM.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/UI_Button_Forward");
            HPRegen.gameObject.SetActive(false);
            PM.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(this);
    }

    private void Start()
    {
        HPRegen.gameObject.SetActive(false);
    }
}
