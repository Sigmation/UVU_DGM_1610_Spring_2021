using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{
    //set the top boundary for objects being destoryed
    private float topBound = 35.0f;
    //set the bottom boundary for objects being destoryed
    private float lowerBound = -15.0f;
    // Update is called once per frame
    void Update()
    {
        //Destroy prefab if its z axis is more then topBound
        if (transform.position.z > topBound)
        {
        // Destroy this object that this script is attached to
        Destroy(gameObject);
        }
        //Destroy prefab if its z axis is more then lowerBound
        else if (transform.position.z < lowerBound)
        {
        //display GameOver if animal is destroyed off camera
        Debug.Log("GAME OVER!");
        // Destroy this object that this script is attached to
        Destroy(gameObject);
        }
    }
}
