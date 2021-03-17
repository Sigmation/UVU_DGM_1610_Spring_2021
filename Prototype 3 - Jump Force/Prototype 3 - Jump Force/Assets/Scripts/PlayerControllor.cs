using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    //seting up varables
    private Rigidbody playerRb;
    //jump force applyed
    public float jumpForce;
    //graviy modifier
    public float gravityMod;
    // setting up ground check
    public bool isOnGround = true;
    // setting up GameOver check
    public bool isGameOver = false;
    //sets up animation
    private Animator playerAnim;
    //sets up particles
    public ParticleSystem dirtKickUp;
    public ParticleSystem explotion;
    //sets up sound
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //declaring the player rigibody
        playerRb = GetComponent<Rigidbody>();
        //setting player gravity
        Physics.gravity *= gravityMod;
        //calling the Animator
        playerAnim = GetComponent<Animator>();
        //calling the audiosource
        playerAudio = GetComponent<AudioSource>();
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
            //play jump animation
            playerAnim.SetTrigger("Jump_trig");
            //stop dirt particles
            dirtKickUp.Stop();
            //play jump sound
            playerAudio.PlayOneShot(jumpSound);
        }
    }
    //OnCollisionEnter is called once per collision
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //set player on ground to true
            isOnGround = true;
            Debug.Log("Grounded");
            //play dirt particle effect
            dirtKickUp.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            //setting gameover to true
            isGameOver = true;
            Debug.Log("Game Over!");
            //death animation
            playerAnim.SetBool("Death_b",true);
            //picking the animation
            playerAnim.SetInteger("DeathType_int", 1);
            //play explotion particle
            explotion.Play();
            //stop dirt particle
            dirtKickUp.Stop();
            //play death sound
            playerAudio.PlayOneShot(crashSound);
        }
    }
}
