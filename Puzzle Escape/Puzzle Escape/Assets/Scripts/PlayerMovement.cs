using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // setting the movement speed for the player
    public float speed = 30.0f;
    //setting horizontal movement
    private float hinput;
    //setting forward and backward movement
    private float finput;

    // Update is called once per frame
    void Update()
    {
        // gathers the imputs for the controls
        hinput = Input.GetAxis("Horizontal");
        finput = Input.GetAxis("Vertical");
        //moveing the player when imputs are pressed
        transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);

    }
}
