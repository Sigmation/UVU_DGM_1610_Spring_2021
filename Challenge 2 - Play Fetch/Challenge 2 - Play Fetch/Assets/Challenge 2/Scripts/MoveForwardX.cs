using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    //sets the speed of the objects attatched
    public float speed;

    // Update is called once per frame
    void Update()
    {
        //moves the objects attached forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
