using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // setting the speed of the car
    private float Speed = 30.0f;
    // setting the turn speed of the car
    private float turnSpeed = 60.0f;
    //horizontal movement
    private float Hinput;
    //forward movement
    private float Finput;

    // Update is called once per frame
    void Update()
    {
        // gathers the imputs for the controls
        Hinput = Input.GetAxis("Horizontal");
        Finput = Input.GetAxis("Vertical");
        // makes the player car go forward and back
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * Finput);
        // makes the player car go left and right
        transform.Rotate(Vector3.up, turnSpeed * Hinput * Time.deltaTime);
    }
}
