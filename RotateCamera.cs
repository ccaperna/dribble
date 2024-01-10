using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xIn = Input.GetAxis("Horizontal");
        //Vector3.up == y 
        transform.Rotate(Vector3.up, rotationSpeed * xIn * Time.deltaTime);
    }
}
