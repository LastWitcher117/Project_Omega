using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public GameManagerScript gms;

    public Animator P_Animator;

    public bool isWalking;
    public bool isDashing;

    public GameObject Player;


    void Start()
    {
        P_Animator = Player.GetComponent<Animator>();
    }


    void Update()
    {
        if(isWalking == true)
        {
            P_Animator.SetBool("Running", true);
        }
        else
        {
            P_Animator.SetBool("Running", false);
        }

        if(isDashing == true)
        {
            P_Animator.SetBool("Dashing", true);
        }
        else
        {
            P_Animator.SetBool("Dashing", false);
        }
    }
}
