using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    //seting up varables
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityMod;
    // setting up ground check
    public bool isOnGround = true;
    public bool isGameOver = false;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        //declaring the player rigibody
        playerRb = GetComponent<Rigidbody>();
        //setting player gravity
        Physics.gravity *= gravityMod;
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //If space is pressed on ground then jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !isGameOver)
        {
            //makes the player jump
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //sets on ground to false
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    //OnCollisionEnter is called once per collision
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //set player on ground to true
            isOnGround = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
