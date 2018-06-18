using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    //Variables
    public Transform target;
    public Vector3 offset;

    public float pitch = 2.0f;
    public float zoomSpeed = 4.0f;
    public float minZoom = 5.0f;
    public float maxZoom = 15.0f;

    private float currentZoom = 10f;
    private float yawSpeed = 100.0f;
    private float currentYaw = 0;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;  //Gets the mouse wheel
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);       //Clamps the currentZoom between minZoom and maxZoom

        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime; //Gets the Horizontal keys (A and D) and times it by the speed we want it to rotate it at
    }

    //Calls right after normal update
    void LateUpdate()
    {
        //Sets the camera's position to the targets position
        transform.position = target.position - offset * currentZoom;
        //Looks at the targets position
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);  //Rotates the camera's position around the target
    }
}
