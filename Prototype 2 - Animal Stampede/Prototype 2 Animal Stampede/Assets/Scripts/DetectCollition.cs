using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollition : MonoBehaviour
{

    // OnTriggerEnter is called once per collition
    void OnTriggerEnter(Collider other)
    {
        // Destroy this object that this script is attached to
        Destroy(gameObject);
        // Destory other object that hits a trigger
        Destroy(other.gameObject);
    }
}
