using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //set move speed of the player
    public float speed = 20.0f;
    //store the hinput
    public float hInput;

    // Update is called once per frame
    void Update()
    {
        //declare hinput as the Horizontal Axis
        hInput = Input.GetAxis("Horizontal");
        //setting left peramiters for movment
        if(transform.position.x < -10){
         transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        //setting right peramiters for movment
        else if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        //pushing the player on the x axis based on hinput
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
    }
}
