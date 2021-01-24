using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTurner : MonoBehaviour
{

    /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
    //Sprite/Material/whatever turning to camera
    public Transform target;

    public float ObjectTurningSpeed;
    /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/


    void Update()
    {
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
        var step = ObjectTurningSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, step);
        /*/-------------------------------------------------------------------------------------------------------------------------------------------------/*/
    }
}
