using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    //calling the plane and storeing it
    public GameObject plane;
    //setting the offset
    private Vector3 offset = new Vector3(30, 0, 0);

    // Update is called once per frame
    void Update()
    {
        //have the camera follow the plane
        transform.position = plane.transform.position + offset;
    }
}
