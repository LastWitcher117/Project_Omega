using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardianVolumeController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerGobject;

    GuardianPatrol eDistScript;
    float enemyDistance;

    // Start is called before the first frame update
    void Start()
    {
        eDistScript = GetComponent<GuardianPatrol>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyDistance = eDistScript.LookRadiusDistance();
        playerGobject.GetComponent<ThirdPersonMovement>().PlayerFootStepsVolume(enemyDistance);
    }
}
