using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTutorial : MonoBehaviour
{
    public PlayerAttack PA;

    public GameObject Enemy;
    public EnemyController EController;

    public Canvas HowToAttack;
    public Canvas HowToDash;

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
                Time.timeScale = 0f;
                HowToAttack.gameObject.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0) && PA.AttackNow.enabled == true)
            {
                Time.timeScale = 1f;
                EController.SupressMovement = true;

                HowToAttack.gameObject.SetActive(false);
                FirstTimeAttack = true;
                
            }

        }     

        if (FirstTimeDash == true)
        {
            if (PA.AttackNow.enabled == true)
            {
                PA.AttackNow.enabled = false;
                Time.timeScale = 0f;
                HowToDash.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Time.timeScale = 1f;


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
