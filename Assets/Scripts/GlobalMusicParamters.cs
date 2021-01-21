using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicParamters : MonoBehaviour
{
    [SerializeField]
    List<EnemyController> Enemies;

    [SerializeField]
    List<GuardianPatrol> EnemyGuardian;

    public bool HuntingEnemy;
    public bool HuntingEnemyOld;

    public bool HuntingEnemyGuardian;
    public bool HuntingEnemyGuardianOld;

    public bool roamingMusic;
    public bool ChasingMusic;

    private void Start()
    {
        Enemies = new List<EnemyController>(FindObjectsOfType<EnemyController>());

        EnemyGuardian = new List<GuardianPatrol>(FindObjectsOfType<GuardianPatrol>());
    }

    private void Update()
    {
        HuntingEnemy = false;
        foreach (var Enemy in Enemies) // Cycled alle gegner 
        {
            if (Enemy.Hunting == true) //Geht eenenmy.hunting 
            {
                HuntingEnemy = true;
            
                //hier der code von Hector für chase music;

                break; //stopped for-schleife
            }

        }

        HuntingEnemyGuardian = false;
        foreach (var EnemyG in EnemyGuardian) // Cycled alle gegner 
        {
            if (EnemyG.Hunting == true) //Geht eenenmy.hunting 
            {
                HuntingEnemyGuardian = true;

                //hier der code von Hector für chase music;

                break; //stopped for-schleife
            }

        }

        if (HuntingEnemy != HuntingEnemyOld || HuntingEnemyGuardian != HuntingEnemyGuardianOld) //wenn sich was verändert dann schlag aus (an bool)
        {
            HuntingEnemyOld = HuntingEnemy;
            HuntingEnemyGuardianOld = HuntingEnemyGuardian;

            Debug.Log("Player is being Hunted");
            SwapMusic(HuntingEnemy||HuntingEnemyGuardian);
           
        }
        
    }
    private void SwapMusic(bool isHunting)   
    {
        Debug.Log(isHunting ? "Player was found" : "Enemies lost the Player"); //Advanced Debug.Log mit integrierter if schleife | 
                                                                                //immer eine true / false Bedingung muss gesetzt werden
        roamingMusic = !isHunting;
        ChasingMusic = isHunting;


    }


}
