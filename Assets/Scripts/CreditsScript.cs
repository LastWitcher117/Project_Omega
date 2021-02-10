using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject GreenMask;

    public Animator GhostEndScreen;

    public bool Ghostanim = false;

    public void GetIntoCredits()
    {
        MainMenu.SetActive(false);
        CreditsMenu.SetActive(true);

        StartCoroutine(CreditWaiter());

    }

    IEnumerator CreditWaiter()
    {
        yield return new WaitForSeconds(52);

   
       
        GreenMask.SetActive(true);
        StartCoroutine(SecondAnimWaiter());
    }

    private void Update()
    {
        if(Ghostanim == true)
        {
            GhostEndScreen.SetBool("SecondAnim", true);
        }
    }

    IEnumerator SecondAnimWaiter()
    {
        yield return new WaitForSeconds(5);
        Ghostanim = true;

        yield return new WaitForSeconds(7);

        Ghostanim = false;

        GreenMask.SetActive(false);
    }
}
