using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // setting the speed of the car
    public float speed = 7.0f;
    //horizontal movement
    public float Hinput;
    //forward movement
    public float Finput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hinput = Input.GetAxis("Horizontal");
        Finput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Finput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * Hinput);
    }
}
