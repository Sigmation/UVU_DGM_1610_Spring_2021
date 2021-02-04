using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    private float topBound = 35.0f;
    private float lowerBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy prefab if its z axis is more then topBound
        if (transform.position.z > topBound)
        {
        Destroy(gameObject);
        }
        //Destroy prefab if its z axis is more then lowerBound
        else if (transform.position.z < lowerBound)
        {
        Destroy(gameObject);
        }
    }
}
