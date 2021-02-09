using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBugFixer : MonoBehaviour
{

    public GameManagerScript GMS;

    private void OnTriggerEnter(Collider other)
    {
        GMS.TutorialWeapon = false;
    }

}
