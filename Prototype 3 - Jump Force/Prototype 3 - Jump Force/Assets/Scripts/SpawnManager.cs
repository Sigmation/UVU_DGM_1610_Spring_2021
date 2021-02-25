using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;

    private Vector3 spawnPos = new Vector3(25,0,0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        //set the animalindex to equal the leanth of animalPrefabs array
        int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
        //spawns the animal prefabs at the spawnPos
        Instantiate(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
    }
}
