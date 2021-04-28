using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRandomizer : MonoBehaviour
{
    public GameObject boxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(boxPrefab, RandomBoxPos(), boxPrefab.transform.rotation);
    }
    // Create Random Spawn position For the Box
    private Vector3 RandomBoxPos()
    {
        float spawnPosX = Random.Range(-18, -35);
        float spawnPosZ = Random.Range(-19, -27);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
