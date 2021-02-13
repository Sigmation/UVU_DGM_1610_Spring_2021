using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    //Sets the spawn peramiters for x left
    private float spawnLimitXLeft = -22.0f;
    //Sets the spawn peramiters for x right
    private float spawnLimitXRight = 7.0f;
    //sets the spawn position
    private float spawnPosY = 30.0f;
    //sets the spawn interval
    private float spawnInterval = 4.0f;
    //min time for random spawn interval
    private float minTime = 3.0f;
    //max time for random spawn interval
    private float maxTime = 5.0f;
    // Start is called before the first frame update
    private void Start()
    {
        //invokes the SpawnRandomBall method
        Invoke("SpawnRandomBall", spawnInterval);
    }
    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        //sets a random spawnInterval using minTime and maxTime
        spawnInterval = Random.Range(minTime, maxTime);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        //set the balllindex to equal the leanth of ballPrefabs
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        //loops SpawnRandomBall with random spawnInterval
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
