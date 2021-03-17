using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //setting the movement speed
    public float speed = 30;
    private PlayerControllor playerControllorScript;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        // Finds and stores PlayerControler script for later use
        playerControllorScript = GameObject.Find("Player").GetComponent<PlayerControllor>();
    }
    // Update is called once per frame
    void Update()
    {       
        // If game over is false move left
        if(playerControllorScript.isGameOver == false)
        {
            // Objects attached to script move left multiplied bt the speed
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //Destroys objests with Obstacle tag when out of bounds
            Destroy(gameObject);
        }
    }
}
