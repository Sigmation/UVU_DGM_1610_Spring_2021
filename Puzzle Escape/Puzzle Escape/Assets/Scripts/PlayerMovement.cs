﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 500.0f;
    public float jump = 8;
    public float gravity = 2;
   
    private float hinput;
    private float finput;
    private float rinput;
    private float vinput;

    public bool isOnGround = true;
    public bool buttonPressed = false;
    public bool doorOpen = false;

    private Rigidbody playerRb;

    public GameObject spawnPoint;
    public GameObject robot;
    public GameObject playerCamera;
    public GameObject robotCamera;



    // Start is called before the first frame update
    void Start()
    {
        //declare player rigidbody
        playerRb = GetComponent<Rigidbody>();
        //set gravity
        Physics.gravity *= gravity;
       
    }

    // Update is called once per frame
    void Update()
    {
        //set himput to horizontal movement
        hinput = Input.GetAxis("Horizontal");
        //set fimput to vertical movement
        finput = Input.GetAxis("Vertical");
        //set rimput to mouse x movement
        rinput = Input.GetAxis("Mouse X");
        //set vimput to mouse y movement
        vinput = Input.GetAxis("Mouse Y");
        // if Robot control button is not pressed player can move
        if (buttonPressed == false)
        {
            // Swap camera to player camera
            playerCamera.gameObject.SetActive(true);
            robotCamera.gameObject.SetActive(false);
            //move forwad and back with Vertical movment
            transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
            //move left and right with Horizontal movment
            transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
            //rotate player with mouse x
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * rinput);
        }
        // if Robot control button is pressed robot can move
        if (buttonPressed == true)
        {
            // Swap camera to robot camera
            robotCamera.gameObject.SetActive(true);
            playerCamera.gameObject.SetActive(false);
        }


        // jump if space pressed and on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && buttonPressed == false)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            //set player on ground to false
            isOnGround = false;
        }
    }
    //OnCollisionEnter is called once per collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && buttonPressed == false)
        {
            //set player on ground to true
            isOnGround = true;
            Debug.Log("Grounded");
        }
    }
    // If player touches lava then they respawn
    private void OnTriggerEnter(Collider other)
    {
        // If player touches lava then they respawn
        if (other.gameObject.CompareTag("Lava") && buttonPressed == false)
        {
            transform.position = spawnPoint.transform.position;
            isOnGround = false;
            Debug.Log("Respawn");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && other.gameObject.CompareTag("Button") && buttonPressed == false && doorOpen == false)
        {
            buttonPressed = true;
            Debug.Log("Button Pressed");
        }
    }
}
