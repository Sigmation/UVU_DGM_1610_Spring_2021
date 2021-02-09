using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //seting array for animals
    public GameObject[] animalPrefabs;
    //sets the range for x axis that animals spawn
    private float spawnRangeX = 20.0f;
    //sets how far back animals spawn on z
    private float spawnPosZ = 20.0f;
    //timer for spawn delay
    private float startDelay = 2.0f;
    //Delay between spawns
    private float spawnInterval = 1.5f;
    //Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawmRamdomAnimals", startDelay, spawnInterval);
    }
    // Update is called once per frame
    void Update()
    {

    }
    // SpawmRamdomAnimal is called once per InvokeRepeating in void spawn
    void SpawmRamdomAnimals()
    {
    // Randomly genetate animal spawn position and animal type
    Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    int animalIndex = Random.Range(0, animalPrefabs.Length);
    Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
