using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;

    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an Enemy
        SpawnEnemyWave(waveNumber);

        // Create PowerUp for the player to collect
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // Find how many enemies are in play
        enemyCount = FindObjectsOfType<Enemy>().Length;
        // If enemy count gets down to 0 spawn a greater number of enemies
        if(enemyCount == 0)
        {
            waveNumber ++;
            SpawnEnemyWave(waveNumber);
            // Create PowerUp for the player to collect
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Spawn number of enemies based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
