using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    //when the ball collides with the dog destroy it
    private void OnTriggerEnter(Collider other)
    {
        // Destroy this object that this script is attached to
        Destroy(gameObject);
    }
}
