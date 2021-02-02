using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //set the move speed of the sandwich
    private float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        //pushes the sandwich on the z axis
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
