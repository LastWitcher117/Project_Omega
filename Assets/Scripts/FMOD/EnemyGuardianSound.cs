using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardianSound : MonoBehaviour
{
    FMOD.Studio.EventInstance enemySound;
    
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemySound = FMODUnity.RuntimeManager.CreateInstance("event:/Enemy/GhostSound 2");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(enemySound, transform, rb);
        enemySound.start();
        enemySound.release();
        
        
    }

    private void Update()
    {
        
    }
}
