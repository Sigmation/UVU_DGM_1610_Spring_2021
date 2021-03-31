using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private GameObject focalPoint;
    private Rigidbody playerRb;

    public bool hasPowerUp;
    public float powerUpStrength = 16;

    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, 0.2f, 0);
    }

    // OnTriggerEnter is called once per trigger collition
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log("Powerup Collected");

            StartCoroutine(PowerupCountdownRoutine());

            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // Gets the enemies rigidbody component so we can have acces to its physicl properties
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Gets the postion of the enemy in relation to the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            // Report player collition with the enemy
            Debug.Log("Player has collided with " + collision.gameObject + " with power up set to " + hasPowerUp);
            // On collition kicks enemy back
            enemyRigidbody. AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7); hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
