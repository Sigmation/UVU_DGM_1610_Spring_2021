using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private int playerHealth = 4;
    private float speed = 5.0f, turnSpeed = 500.0f, jump = 8, gravity = 2, hinput, finput, rinput, vinput;
    private PlayerMovement playerMovementScript;
    private GameManager gameManagerScript;
    public bool isOnGround = true;
    private Rigidbody robotRb;
    public GameObject spawnPoint, door, button, robot;
    private Animator doorAnim, buttonAnim, robotAnim;
    public ParticleSystem shockEffect;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Declare robot rigidbody
        robotRb = GetComponent<Rigidbody>();
        doorAnim = door.GetComponent<Animator>();
        buttonAnim = button.GetComponent<Animator>();
        robotAnim = robot.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        // Set himput to horizontal movement
        hinput = Input.GetAxis("Horizontal");
        // Set fimput to vertical movement
        finput = Input.GetAxis("Vertical");
        // Set rimput to mouse x movement
        rinput = Input.GetAxis("Mouse X");
        // Set vimput to mouse y movement
        vinput = Input.GetAxis("Mouse Y");
        if (playerMovementScript.buttonPressed == true && gameManagerScript.gamePause == false)
        {
            // Move forwad and back with Vertical movment
            transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
            // Move left and right with Horizontal movment
            transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
            // Rotate player with mouse x
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * rinput);
            // If Robot is moveing animate walk
            if (finput >= 1 && isOnGround)
            {
                robotAnim.SetInteger("Speed", 1);
            }
            else if (finput < 0 && isOnGround)
            {
                robotAnim.SetInteger("Speed", 1);
            }
            else if (hinput >= 1 && isOnGround)
            {
                robotAnim.SetInteger("Speed", 1);
            }
            else if (hinput < 0 && isOnGround)
            {
                robotAnim.SetInteger("Speed", 1);
            }
            else
            {
                robotAnim.SetInteger("Speed", 0);
            }
        }
        // Jump if space pressed and on ground but for robot
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && playerMovementScript.buttonPressed == true && gameManagerScript.gamePause == false)
        {
            robotRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // Set robot on ground to false
            isOnGround = false;
            robotAnim.SetBool("Jumping", true);
            robotAnim.SetInteger("Speed", 0);
        }
    }
    // If Robot touches the ground set robot isOnGround to true
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Debug.Log("Grounded");
            robotAnim.SetBool("Jumping", false);
        }
        // If robot touches button open the door
        if (collision.gameObject.CompareTag("Button") && playerMovementScript.doorOpen == false)
        {
            gameManagerScript.gameAudio.PlayOneShot(gameManagerScript.completedSound);
            playerMovementScript.buttonPressed = false;
            playerMovementScript.doorOpen = true;
            buttonAnim.SetBool("robotOnButton", true);
            doorAnim.SetBool("doorIsOpen", true);
            gameManagerScript.gameAudio.PlayOneShot(gameManagerScript.doorOpenSound);
            Debug.Log("RobotButton");
        }
    }
    // If robot touches lava then they respawn and damage the player
    private void OnTriggerEnter(Collider other)
    {
        // If player touches lava then they respawn
        if (other.gameObject.CompareTag("Lava"))
        {
            shockEffect.Play();
            playerMovementScript.playerAudio.PlayOneShot(playerMovementScript.shock);
            playerHealth -= 1;
            playerMovementScript.HealthBar(playerHealth);
            transform.position = spawnPoint.transform.position;
            playerMovementScript.buttonPressed = false;
            Debug.Log("Respawn");
        }
    }
}
