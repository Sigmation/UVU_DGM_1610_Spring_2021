using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    //calls the Dog prefab
    public GameObject dogPrefab;
    //sets a delay for spawn
    private float spawnDelay = 1.0f;
    //gives spawn delay a way to chek agenst game time
    private float time;
    // Update is called once per frame
    void Update()
    {
        // On gametime being more then time and on spacebar press, send dog
        if (Time.time > time && Input.GetKeyDown(KeyCode.Space))
        {
        //summon a dog at player location
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        //resets the delay for time
        time = spawnDelay + Time.time;
        }
    }
}
