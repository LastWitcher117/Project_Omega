using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Darkener : MonoBehaviour
{

    public Image ScreenDarkener;
    //public float Darkness = 0f;
    public bool isInTrigger = false;

    public float Dark_Light_Value = 0.1f;
    public float Timing = 0.5f;

    public Color Darkness;

    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
    }

    private void Update()
    {

       

        if (isInTrigger == true)
        {
            InvokeRepeating("DarkerScreen", Timing, Timing);

        }
        else
        {
            InvokeRepeating("LighterScreen", Timing, Timing);
        }



    }

    void DarkerScreen()
    {
        if (Darkness.a <= 0.6)
        {
            CancelInvoke("DarkerScreen");

            Darkness.a = Darkness.a + Dark_Light_Value;

            ScreenDarkener.color = Darkness;
        }
    }

    void LighterScreen()
    {
        if (Darkness.a >= 0)
        {
            CancelInvoke("LighterScreen");

            Darkness.a = Darkness.a - Dark_Light_Value;

            ScreenDarkener.color = Darkness;
        }
    }

}
