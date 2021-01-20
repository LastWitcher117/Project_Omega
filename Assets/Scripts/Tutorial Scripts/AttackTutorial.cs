using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTutorial : MonoBehaviour
{
    public PlayerAttack PA;

    public GameObject Enemy;
    public EnemyController EController;
    public AnimationController AC;

    public GameObject HowToAttack;
    public GameObject HowToDash;

    public bool FirstTimeAttack = false;
    public bool FirstTimeDash = false;
    public bool SecondTimeDash = false;


    // Update is called once per frame
    void Update()
    {
        if (FirstTimeAttack == false)
        {
            if (PA.AttackNow.enabled == true)
            {               
                AC.inTutorial = true;
                HowToAttack.gameObject.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                AC.inTutorial = false;
                EController.SupressMovement = false;

                HowToAttack.gameObject.SetActive(false);
                FirstTimeAttack = true;
                
            }

        }     

        if (FirstTimeDash == true)
        {
            if (PA.AttackNow.enabled == true)
            {
                AC.inTutorial = true;
                HowToDash.gameObject.SetActive(true);
                
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                AC.inTutorial = false;
                EController.SupressMovement = false;

                HowToDash.gameObject.SetActive(false);
                FirstTimeDash = false;
                SecondTimeDash = true;
            }

        }
        
     }

    private void OnTriggerExit(Collider other)
    {
        if (SecondTimeDash == false)
        {
            FirstTimeDash = true;
        }
    }

}
