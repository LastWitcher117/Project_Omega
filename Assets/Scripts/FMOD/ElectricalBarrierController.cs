using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalBarrierController : MonoBehaviour
{
    public GameObject ElectricalBarrier3a;
    public GameObject ElectricalBarrier3b;

    public DoorTrigger DT;
    public ElectricalBarrierController EBC;

    public bool ActivateEB3a = false;

    public bool SoundIsPlaying = false;

    public bool InPause = false;

    public bool PressResume = false;

    public bool SecondSound = false;

    public bool hasKeyStartSound = true;

    public bool dontPause = false;

    // Update is called once per frame
    void Update()
    {
        if (ActivateEB3a == true)
        {

            ElectricalBarrier3a.SetActive(true);
            SoundIsPlaying = true;
        }

        if (DT.hasKey == true && hasKeyStartSound == true)
        {
            StartCoroutine(SoundTiming());
         
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SoundIsPlaying == true && InPause == false && dontPause == false)
        {
            ElectricalBarrier3a.SetActive(false);
            ElectricalBarrier3b.SetActive(false);
            EBC.ActivateEB3a = false;
            InPause = true;

        }

        if (PressResume == true)
        {
            ElectricalBarrier3a.SetActive(true);           
            EBC.ActivateEB3a = true;
            PressResume = false;
            InPause = false;


            /*/
            if(SecondSound == true)
            {
                ElectricalBarrier3b.SetActive(true);
            }
            /*/

        }

    }

    IEnumerator SoundTiming()
    {
        hasKeyStartSound = false;
        yield return new WaitForSeconds(7);

        ElectricalBarrier3b.SetActive(true);
        SecondSound = true;
        StartCoroutine(SoundTransission());
    }

    IEnumerator SoundTransission()
    {
        yield return new WaitForSeconds(0.5f);
        ElectricalBarrier3a.SetActive(false);
    }

}
