using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 500.0f;
    public float jump = 8;
    public float gravity = 2;

    private float hinput;
    private float finput;
    private float rinput;
    private float vinput;

    private PlayerMovement playerMovementScript;
    private GameManager gameManagerScript;

    public bool isOnGround = true;
    private Rigidbody robotRb;

    public GameObject spawnPoint;
    public GameObject door;
    public GameObject button;
    public GameObject robot;

    private Animator doorAnim;
    private Animator buttonAnim;
    private Animator robotAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        //declare robot rigidbody
        robotRb = GetComponent<Rigidbody>();
        doorAnim = door.GetComponent<Animator>();
        buttonAnim = button.GetComponent<Animator>();
        robotAnim = robot.GetComponent<Animator>();
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

        if (playerMovementScript.buttonPressed == true && gameManagerScript.gamePause == false)
        {
            //move forwad and back with Vertical movment
            transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
            //move left and right with Horizontal movment
            transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
            //rotate player with mouse x
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
        // jump if space pressed and on ground but for robot
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && playerMovementScript.buttonPressed == true && gameManagerScript.gamePause == false)
        {
            robotRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            //set robot on ground to false
            isOnGround = false;
            robotAnim.SetBool("Jumping", true);
            robotAnim.SetInteger("Speed", 0);
        }
    }
    //OnCollisionEnter is called once per collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //set robot on ground to true
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
    // If robot touches lava then they respawn
    private void OnTriggerEnter(Collider other)
    {
        // If player touches lava then they respawn
        if (other.gameObject.CompareTag("Lava"))
        {
            transform.position = spawnPoint.transform.position;
            playerMovementScript.buttonPressed = false;
            Debug.Log("Respawn");
        }
    }
}
