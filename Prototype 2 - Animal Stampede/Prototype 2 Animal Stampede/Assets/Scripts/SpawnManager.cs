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
        //InvokeRepeating so that SpawmRamdomAnimals keeps happening
        InvokeRepeating("SpawmRamdomAnimals", startDelay, spawnInterval);
    }
    // SpawmRamdomAnimal is called once per InvokeRepeating in void spawn
    void SpawmRamdomAnimals()
    {
    // Randomly genetate animal spawn position and animal type
    Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    //set the animalindex to equal the leanth of animalPrefabs array
    int animalIndex = Random.Range(0, animalPrefabs.Length);
    //spawns the animal prefabs at the spawnPos
    Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
