using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //calling the car and storing it
    public GameObject Player;
    //setting an offset for the camera
    private Vector3 Offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void Update()
    {
        //get the camera to follow the car
        transform.position = Player.transform.position + Offset;
    }
}
