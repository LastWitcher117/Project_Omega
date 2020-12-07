using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI2 : MonoBehaviour
{
    private Transform player;
    private float distance;
    public float moveSpeed;
    public float howClose;

    public Canvas You_Lose_Screen;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if (distance <= howClose)
        {
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        }

        //for melee attack or explosive
        /*if (distance <= 1.5f)
        {
            //Do Damage or explode
            Health HealthComponent = GetComponent<Health>();

            HealthComponent.health--;
            //Cooldown = true;
            FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)

            if (HealthComponent.health == 0)
            {
                You_Lose_Screen.enabled = true;
                SceneManager.LoadScene(1);
            }
        }*/

    }
}
