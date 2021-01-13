using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameManagerScript gms;

    public Animator P_Animator;

    public GameObject Player;


    public bool isWalking;
    public bool isDashing;
    public bool isAttacking;
    public bool isDying;

    public Health ay;

    void Start()
    {
        P_Animator = Player.GetComponent<Animator>();
    }


    void Update()
    {
        /*if (Input.GetKey(KeyCode.Mouse1))
        {
            isDying = true;
        }*/

       if ( ay.health == 0 )
        {
            isDying = true;
        }

/*/----------------------------------------------------------------------/*/
        if (isWalking == true)
        {
            P_Animator.SetBool("Running", true);
        }
        else
        {
            P_Animator.SetBool("Running", false);
        }
/*/----------------------------------------------------------------------/*/
        if(isDashing == true)
        {
            P_Animator.SetBool("Dashing", true);
        }
        else
        {
            P_Animator.SetBool("Dashing", false);
        }
/*/----------------------------------------------------------------------/*/
        if (isAttacking == true)
        {
            P_Animator.SetBool("Attacking", true);
        }
        else
        {
            P_Animator.SetBool("Attacking", false);
        }
        /*/----------------------------------------------------------------------/*/
        if (isDying == true)
        {
            P_Animator.SetBool("Dying", true);
        }
        else
        {
            P_Animator.SetBool("Dying", false);
        }
        /*/----------------------------------------------------------------------/*/
    }
}
