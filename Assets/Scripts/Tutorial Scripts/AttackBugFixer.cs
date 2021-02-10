using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBugFixer : MonoBehaviour
{

    public GameManagerScript GMS;

    public bool AlwaysAttack;

    private void OnTriggerEnter(Collider other)
    {
        GMS.TutorialWeapon = false;
    }

    private void Update()
    {
        if(AlwaysAttack == true)
        {
            GMS.TutorialWeapon = false;
            
        }
    }

}
