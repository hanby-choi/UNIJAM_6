using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        rotationSpeed = 30f;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);

        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);

    }
}