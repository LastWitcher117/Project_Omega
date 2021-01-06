using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClipping : MonoBehaviour
{
    public float cameraSmoothingFactor = 1;
    public float lookUpMax = 60;
    public float lookUpMin = -60;

    public Transform t_camera;

    private Quaternion camRotation;
    private RaycastHit hit;
    private Vector3 camera_offset;
    void Start()
    {
        camRotation = transform.localRotation;
        camera_offset = t_camera.localPosition;
    }

    
    void Update()
    {
        camRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * (-1);
        camRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor;

        camRotation.x = Mathf.Clamp(camRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);

        if(Physics.Linecast(transform.position, t_camera.position+transform.localRotation*camera_offset, out hit))
        {
            t_camera.localPosition = new Vector3(0, 0,- Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            t_camera.localPosition = Vector3.Lerp(t_camera.localPosition, camera_offset, Time.deltaTime);
        }

    }
}
