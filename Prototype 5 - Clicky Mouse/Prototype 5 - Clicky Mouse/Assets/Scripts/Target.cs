﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targeRb;

    private float minSpeed = 12, maxSpeed = 16, maxTorque = 10, xRange = 4, ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explotionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targeRb = GetComponent<Rigidbody>();
        targeRb.AddForce(RandomForce(), ForceMode.Impulse);
        targeRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnMouseDown()
    { 
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over!");
            gameManager.GameOver();
        }
    }
}