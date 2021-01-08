using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVolumeController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerGobject;

    EnemyController eDistScript;
    float enemyDistance;

    // Start is called before the first frame update
    void Start()
    {
        eDistScript = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyDistance = eDistScript.LookRadiusDistance();
        playerGobject.GetComponent<ThirdPersonMovement>().PlayerFootStepsVolume(enemyDistance);
    }
}
