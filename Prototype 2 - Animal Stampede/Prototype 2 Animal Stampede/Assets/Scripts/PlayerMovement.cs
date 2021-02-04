using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //set move speed of the player
    public float speed = 20.0f;
    //store the hinput
    public float hInput;
    //set the range for the peramiters
    private float xRange = 19.5f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        //pushing the player on the x axis based on hinput
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
        //declare hinput as the Horizontal Axis
        hInput = Input.GetAxis("Horizontal");
        //setting left peramiters for movment
        if(transform.position.x < -xRange){
         transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //setting right peramiters for movment
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        //Button to shoot projectile
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
