using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    public Canvas You_Lose_Screen;
    bool Cooldown; //Cooldown for attack
    float ElapsedTime;
    public float CooldownTime;
    public GameObject Dmg_Flashscreen;

    public AnimationController re;

    public ThirdPersonMovement ay;


    void Start()
    {
        ElapsedTime = CooldownTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Cooldown == false) //&& Cooldown == false
        {
            Health HealthComponent = other.GetComponent<Health>();

            FindObjectOfType<AudioManager>().Play("EnemyAttack");

            HealthComponent.health--;
            Dmg_Flashscreen.SetActive(true); //Activating red Screen


    Cooldown = true;
            FindObjectOfType<AudioManager>().Play("Hit1"); //TODO: Singleton (Static instance that can be accessed globally)

            StartCoroutine(Waiter());

            if (HealthComponent.health == 0)
            {
                You_Lose_Screen.enabled = true;

                FindObjectOfType<AudioManager>().Stop("Theme");
                FindObjectOfType<AudioManager>().Play("LoseSound");
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 0); //FMOD  // new line
                StartCoroutine(LoseScreen());

            }
        }
    }


    IEnumerator Waiter() //Time Active of red DMG Screen
    {
        yield return new WaitForSeconds(0.3f);
        Dmg_Flashscreen.SetActive(false);
    }

    IEnumerator LoseScreen() //Time Active of red DMG Screen
    {
        ay.enabled = false;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + 3.2f;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1f;
       
        SceneManager.LoadScene(1);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Ghost Game Paused", 1);
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

