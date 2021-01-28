using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //set the speed of the plane
    private float speed = 0.5f;
    //set the rotation speed of the plane
    private float rotationSpeed = 0.0f;
    //set up movement imput
    private float verticalInput;
    //set propeller speed
    private float propellerSpeed = 1000.0f;
    //declares the propeller
    public GameObject propeller;

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left * rotationSpeed * verticalInput * Time.deltaTime);
        //if else statment so only if the up or down key is pressed, will the plane rotate
        if (verticalInput != 0)
        {
            rotationSpeed = 100.0f;
        }
        else {
            rotationSpeed = 0.0f;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        //rotate ptopeller at a constant rate
        propeller.transform.Rotate(Vector3.forward * propellerSpeed * Time.deltaTime);
    }
}
