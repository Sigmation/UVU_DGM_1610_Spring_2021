using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f, turnSpeed = 500.0f, jump = 8, gravity = 2, hinput, finput, rinput, vinput;

    public int nextLevel;

    public bool isOnGround = true;
    public bool buttonPressed = false;
    public bool buttonRadias = false;
    public bool doorOpen = false;
    public bool isAlive = true;

    private Rigidbody playerRb;

    public GameObject robot;
    public GameObject smoke;
    public GameObject playerCamera;
    public GameObject deathCamera;
    public GameObject robotCamera;
    public GameObject player;

    private Vector3 offset = new Vector3(0, 1, -3);

    public ParticleSystem smokeEffect;

    private GameManager gameManagerScript;

    private Animator playerAnim;

    public AudioClip jumpSound;
    public AudioClip controlPanleSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        //declare player rigidbody
        playerRb = GetComponent<Rigidbody>();
        //set gravity
        Physics.gravity *= gravity;
        // hide and lock cursor to screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        playerAnim = player.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // set himput to horizontal movement
        hinput = Input.GetAxis("Horizontal");
        // set fimput to vertical movement
        finput = Input.GetAxis("Vertical");
        // set rimput to mouse x movement
        rinput = Input.GetAxis("Mouse X");
        // set vimput to mouse y movement
        vinput = Input.GetAxis("Mouse Y");
        // Death camera follows the player
        deathCamera.transform.position = transform.position + offset;
        // Smoke particle system follows the player
        smoke.transform.position = transform.position;
        // if Robot control button is not pressed player can move
        if (buttonPressed == false & gameManagerScript.gamePause == false)
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
            // If the player is moving animate walk
            if (finput >= 1 && isOnGround)
            {
                playerAnim.SetInteger("Speed", 1);
            }
            else if (finput < 0 && isOnGround)
            {
                playerAnim.SetInteger("Speed", 1);
            }
            else if (hinput >= 1 && isOnGround)
            {
                playerAnim.SetInteger("Speed", 1);
            }
            else if (hinput < 0 && isOnGround)
            {
                playerAnim.SetInteger("Speed", 1);
            }
            else
            {
                playerAnim.SetInteger("Speed", 0);
            }
        }
        // if Robot control button is pressed robot can move
        if (buttonPressed == true & gameManagerScript.gamePause == false)
        {
            // Swap camera to robot camera
            robotCamera.gameObject.SetActive(true);
            playerCamera.gameObject.SetActive(false);
        }
        // If player is close enough to button and clicks active the button
        if (buttonPressed == false && doorOpen == false && buttonRadias == true && Input.GetKeyDown(KeyCode.Mouse0) & gameManagerScript.gamePause == false)
        {
            Debug.Log("Button Pressed");
            buttonPressed = true;
            playerAnim.SetInteger("Speed", 0);
            playerAudio.PlayOneShot(controlPanleSound);
        }

        // jump if space pressed and on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && buttonPressed == false & gameManagerScript.gamePause == false)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            //set player on ground to false
            isOnGround = false;
            playerAnim.SetBool("Jump", true);
            playerAnim.SetInteger("Speed", 0);
            // Play Jump Sound
            playerAudio.PlayOneShot(jumpSound);
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
            playerAnim.SetBool("Jump", false);
        }
    }
    // If player touches lava then they respawn
    private void OnTriggerEnter(Collider other)
    {
        // If player touches lava Then its GameOver and must retry
        if (other.gameObject.CompareTag("Lava") && buttonPressed == false)
        {
            gameObject.SetActive(false);
            deathCamera.gameObject.SetActive(true);
            gameManagerScript.gameOverText.gameObject.SetActive(true);
            gameManagerScript.retryButton.gameObject.SetActive(true);
            gameManagerScript.gameAudio.PlayOneShot(gameManagerScript.lavaDeathSound);
            smokeEffect.Play();
            Debug.Log("Burned");
            Cursor.visible = true;
            isAlive = false;
            Physics.gravity /= gravity;
        }
        // Got to next level
        if (other.gameObject.CompareTag("Exit"))
        {
            Physics.gravity /= gravity;
            SceneManager.LoadScene(nextLevel);
        }
        // if player enters button area activate button
        if (other.gameObject.CompareTag("Button"))
        {
            Debug.Log("Within Button radias");
            buttonRadias = true;
        }
    }
    // If Player leave button area disable button
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            Debug.Log("Not Within Button radias");
            buttonRadias = false;
        }
    }
    
}
