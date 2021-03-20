using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 500.0f;
    public float jump;
    public float gravity;
   
    private float hinput;
    private float finput;
    private float rinput;
    private float vinput;

    public bool isOnGround = true;

    private Rigidbody playerRb;

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
        //move forwad and back with Vertical movment
        transform.Translate(Vector3.forward * Time.deltaTime * speed * finput);
        //move left and right with Horizontal movment
        transform.Translate(Vector3.right * Time.deltaTime * speed * hinput);
        //rotate player with mouse x
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * rinput);

        //jump if space pressed and on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            //set player on ground to false
            isOnGround = false;
        }
    }
    //OnCollisionEnter is called once per collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //set player on ground to true
            isOnGround = true;
            Debug.Log("Grounded");
        }
    }
}
