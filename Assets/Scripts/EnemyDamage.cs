using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public Canvas You_Lose_Screen;
    bool Cooldown;
    float ElapsedTime;
    public float CooldownTime;

    void Start()
    {
        ElapsedTime = CooldownTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Cooldown == false)
        {
            Health HealthComponent = other.GetComponent<Health>();

            HealthComponent.health--;
            Cooldown = true;
            FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)

            if (HealthComponent.health == 0)
            {
                You_Lose_Screen.enabled = true;
                SceneManager.LoadScene(1);
            }
        }
    }

    void Update()
    {
        if (Cooldown == true)
        {
            ElapsedTime -= Time.deltaTime;
            if (ElapsedTime <= 0f)
            {
                Cooldown = false;
                ElapsedTime = CooldownTime;
            }
        }
    }
}

