using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultySelection : MonoBehaviour
{
    public GameManagerScript gms;

    public GameObject SelectDifficulty;

    public Pause_Menu PM;

    public bool DifficultySet = false;

    public Health Health;

    public AnimationController AC;

    public EnemyController EC1;
    public EnemyController EC2;
    public EnemyController EC3;
    public EnemyController EC4;

    public GuardianPatrol GP1;
    public GuardianPatrol GP2;
    public GuardianPatrol GP3;
    public GuardianPatrol GP4;
    public GuardianPatrol GP5;
    public GuardianPatrol GP6;
    public GuardianPatrol GP7;

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        AC.inTutorial = false;
        PM.isPause = true;
        SelectDifficulty.SetActive(true);
        Time.timeScale = 0f;
        gms.HPUpdate = true;
    
    }

    public void EasyDifficulty()
    {
        EC1.StunTime = 3f;    
        EC2.StunTime = 3f;
        EC3.StunTime = 3f;
        EC4.StunTime = 3f;

        GP1.StunTime = 3f;
        GP2.StunTime = 3f;
        GP3.StunTime = 3f;
        GP4.StunTime = 3f;
        GP5.StunTime = 3f;
        GP6.StunTime = 3f;
        GP7.StunTime = 3f;

        gms.PointsNeededForHealth = 50;

        SelectDifficulty.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        DifficultySet = true;
        PM.isPause = false;
    }

    public void MediumDifficulty()
    {
        EC1.StunTime = 2f;
        EC2.StunTime = 2f;
        EC3.StunTime = 2f;
        EC4.StunTime = 2f;

        GP1.StunTime = 2f;
        GP2.StunTime = 2f;
        GP3.StunTime = 2f;
        GP4.StunTime = 2f;
        GP5.StunTime = 2f;
        GP6.StunTime = 2f;
        GP7.StunTime = 2f;

        gms.PointsNeededForHealth = 200;

        SelectDifficulty.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        DifficultySet = true;
        PM.isPause = false;

    }

    public void HardDifficulty()
    {
        EC1.StunTime = 1f;
        EC2.StunTime = 1f;
        EC3.StunTime = 1f;
        EC4.StunTime = 1f;

        GP1.StunTime = 1f;
        GP2.StunTime = 1f;
        GP3.StunTime = 1f;
        GP4.StunTime = 1f;
        GP5.StunTime = 1f;
        GP6.StunTime = 1f;
        GP7.StunTime = 1f;

        gms.PointsNeededForHealth = 2000;

        SelectDifficulty.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        DifficultySet = true;
        PM.isPause = false;

    }

    public void DarkeaterManus()
    {
        EC1.StunTime = 0.5f;
        EC2.StunTime = 0.5f;
        EC3.StunTime = 0.5f;
        EC4.StunTime = 0.5f;

        GP1.StunTime = 0.5f;
        GP2.StunTime = 0.5f;
        GP3.StunTime = 0.5f;
        GP4.StunTime = 0.5f;
        GP5.StunTime = 0.5f;
        GP6.StunTime = 0.5f;
        GP7.StunTime = 0.5f;

        Health.health--;
        Health.health--;

        gms.PointsNeededForHealth = 90000000;

        SelectDifficulty.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;

        DifficultySet = true;
        PM.isPause = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(DifficultySet == true)
        {
            PM.isPause = false;
            gms.HPUpdate = false;
            Destroy(gameObject);
        }
    }

}
