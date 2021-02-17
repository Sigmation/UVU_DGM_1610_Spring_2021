using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    //seting the left limit for the dog
    private float leftLimit = -30;
    //seting the bottom limit for the ball
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            // Destroy this object that this script is attached to
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            //display GameOver if ball hits the ground
            Debug.Log("GAME OVER!");
            // Destroy this object that this script is attached to
            Destroy(gameObject);
        }

    }
}
