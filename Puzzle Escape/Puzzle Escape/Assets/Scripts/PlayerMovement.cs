using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int nextLevel;
    private float speed = 5.0f, turnSpeed = 500.0f, jump = 8, gravity = 2, hinput, finput, rinput, vinput;
    public bool isOnGround = true, buttonPressed = false, buttonRadias = false, doorOpen = false, isAlive = true;
    private Rigidbody playerRb;
    public GameObject robot, smoke, playerCamera, deathCamera, robotCamera, player;
    private Vector3 offset = new Vector3(0, 1, -3);
    public ParticleSystem smokeEffect;
    private GameManager gameManagerScript;
    private Animator playerAnim;
    public AudioClip jumpSound, controlPanleSound, shock;
    public AudioSource playerAudio;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Declare player rigidbody
        playerRb = GetComponent<Rigidbody>();
        // Set gravity
        Physics.gravity *= gravity;
        // Hide and lock cursor to screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        playerAnim = player.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        // Set Max Health
        HealthBar(4);
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
            // Move forwad and back with Vertical movment
            transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
            // Move left and right with Horizontal movment
            transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
            // Rotate player with mouse x
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
            // If the player loses all there health they have to retry the level
            if (healthBar.value == 0)
            {
                gameObject.SetActive(false);
                deathCamera.gameObject.SetActive(true);
                gameManagerScript.gameOverText.gameObject.SetActive(true);
                gameManagerScript.retryButton.gameObject.SetActive(true);
                Cursor.visible = true;
                isAlive = false;
                Physics.gravity /= gravity;
            }
        }
        // If Robot control button is pressed robot can move
        if (buttonPressed == true & gameManagerScript.gamePause == false)
        {
            // Swap camera to robot camera
            robotCamera.gameObject.SetActive(true);
            playerCamera.gameObject.SetActive(false);
        }
        // If player is close enough to button and clicks active the button
        if (buttonPressed == false && doorOpen == false && buttonRadias == true && Input.GetKeyDown(KeyCode.E) & gameManagerScript.gamePause == false)
        {
            Debug.Log("Button Pressed");
            buttonPressed = true;
            playerAnim.SetInteger("Speed", 0);
            playerAudio.PlayOneShot(controlPanleSound);
        }
        // Jump if space pressed and on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && buttonPressed == false & gameManagerScript.gamePause == false)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // Set player on ground to false
            isOnGround = false;
            playerAnim.SetBool("Jump", true);
            playerAnim.SetInteger("Speed", 0);
            // Play Jump Sound
            playerAudio.PlayOneShot(jumpSound);
        }
    }
    // HealthBar tutorial https://www.youtube.com/watch?v=BLfNP4Sc_iA
    public void HealthBar(int health)
    {
        healthBar.value = health;
    }
    // If player collides with the ground set player on ground to true
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && buttonPressed == false)
        {
            isOnGround = true;
            Debug.Log("Grounded");
            playerAnim.SetBool("Jump", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // If player touches lava set health to 0
        if (other.gameObject.CompareTag("Lava") && buttonPressed == false)
        {
            
            gameManagerScript.gameAudio.PlayOneShot(gameManagerScript.lavaDeathSound);
            smokeEffect.Play();
            Debug.Log("Burned");
            HealthBar(0);
        }
        // If player touches the exit go to next level
        if (other.gameObject.CompareTag("Exit"))
        {
            Physics.gravity /= gravity;
            SceneManager.LoadScene(nextLevel);
        }
        // If player enters button area activate button
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
