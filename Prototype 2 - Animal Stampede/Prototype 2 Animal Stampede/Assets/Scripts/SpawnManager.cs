using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //seting array for animals
    public GameObject[] animalPrefabs;
    public int animalIndex;
    //animalPrefabs[0, 1, 2, 3]
    //animalPrefabs[0] = Bulldog;
    // Update is called once per frame
    void Update()
    {
        //summon an animal when the S key is pressed
        if (Input.GetKeyDown(KeyCode.S)){
            Instantiate(animalPrefabs[animalIndex], transform.position, animalPrefabs[animalIndex].transform.rotation);
            //new Vector3(0, 0, 25)
        }
    }
}
