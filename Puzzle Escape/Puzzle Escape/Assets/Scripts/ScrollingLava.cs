using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingLava : MonoBehaviour
{
    //set the speed for the image scroll
    private float xspeed = -0.01f;
    private float yspeed = -0.01f;

    // Update is called once per frame
    void Update()
    {
        //setting the offset for the image scroll
        float xoffset = Time.time * xspeed;
        float yoffset = Time.time * yspeed;
        //scrooling the image by using the x and y offset
        GetComponent<Renderer>().material.mainTextureOffset = new Vector3(xoffset, yoffset);
    }
}
