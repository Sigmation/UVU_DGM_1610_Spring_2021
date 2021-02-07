using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // setting the movement speed for the player
    private float speed = 5.0f;
    //setting jump hight
    private float jumpHight = 200.0f;
    // setting the rotation speed for the player
    private float turnSpeed = 200.0f;
    //setting horizontal movement
    private float hinput;
    //setting forward and backward movement
    private float finput;
    //setting mouse x rotate
    private float mxinput;
    // Update is called once per frame
    void Update()
    {
        // gathers the imputs for the controls
        hinput = Input.GetAxis("Horizontal");
        finput = Input.GetAxis("Vertical");
        mxinput = Input.GetAxis("Mouse X");
        //moveing the player when imputs are pressed
        transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
        //turning player with mouse
        transform.Rotate(Vector3.up, turnSpeed * mxinput * Time.deltaTime);
        //Button to Jump
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //}
    }
}
