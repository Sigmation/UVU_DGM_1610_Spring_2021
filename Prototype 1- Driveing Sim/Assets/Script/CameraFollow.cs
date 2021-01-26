using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //calling the car and storing it
    public GameObject player;
    //setting an offset for the camera
    private Vector3 Offset = new Vector3(0, 5, -10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the camera to follow the car
        transform.position = player.transform.position + Offset;
    }
}
