using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //calling the player gameobject
    public GameObject player;
    //setting an offset for the camera
    private Vector3 offset = new Vector3(0, 3, -2);

    // Update is called once per frame
    void Update()
    {
        //get the camera to follow the player
        transform.position = player.transform.position + offset;
    }
}
