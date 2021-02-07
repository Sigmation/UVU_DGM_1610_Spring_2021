using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    //setting mouse y rotate
    private float myinput;
    // setting the rotation speed for the camera
    private float turnSpeed = 200.0f;
    // Update is called once per frame
    void Update()
    {
    //setting imput for mouse y
    myinput = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.left, turnSpeed * myinput * Time.deltaTime);
    }
}
