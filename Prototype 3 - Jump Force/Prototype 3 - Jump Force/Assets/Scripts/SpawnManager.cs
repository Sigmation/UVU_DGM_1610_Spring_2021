using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Setting an array for obstaclePrefab
    public GameObject[] obstaclePrefab;
    // Setting start delay time
    public float startDelay = 2.0f;
    // Setting reapeat rate
    public float repeatRate = 2.0f;
    // Setting the postion obstaclePrefabs spawn
    private Vector3 spawnPos = new Vector3(25,0,0);
    private PlayerControllor playerControllorScript;
    // Start is called before the first frame update
    void Start()
    {
        //Repeat SpawnObstacle
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        // Finds and stores PlayerControler script for later use
        playerControllorScript = GameObject.Find("Player").GetComponent<PlayerControllor>();
    }
    // SpawnObstacle is called in Start
    void SpawnObstacle()
    {
        //set the animalindex to equal the leanth of animalPrefabs array
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);

        if (playerControllorScript.isGameOver == false)
        {
            //spawns the animal prefabs at the spawnPos
            Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }
}
