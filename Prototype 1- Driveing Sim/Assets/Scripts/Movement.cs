using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // setting the speed of the car
    private float speed = 30.0f;
    // setting the turn speed of the car
    private float turnSpeed = 60.0f;
    //horizontal movement
    private float hinput;
    //forward movement
    private float finput;

    // Update is called once per frame
    void Update()
    {
        // gathers the imputs for the controls
        hinput = Input.GetAxis("Horizontal");
        finput = Input.GetAxis("Vertical");
        // makes the player car go forward and back
        transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
        // makes the player car go left and right
        transform.Rotate(Vector3.up, turnSpeed * hinput * Time.deltaTime);
    }
}
