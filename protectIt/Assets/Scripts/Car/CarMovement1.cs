using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement1 : MonoBehaviour
{
    public Rigidbody2D carRigidbody1;
    public float carSpeed1;
    public float lifeTime1;
    private Vector2 carVelocity;
    void Start()
    {
        carRigidbody1 = GetComponent<Rigidbody2D>();
        carVelocity = new Vector2(carSpeed1, 0);
        carRigidbody1.velocity = carVelocity;

        Destroy(gameObject, lifeTime1);
    }
}
