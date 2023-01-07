using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement1 : MonoBehaviour
{
    public Rigidbody2D carRigidbody;
    public float carSpeed;
    public float lifeTime;
    private Vector2 carVelocity;
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
        carVelocity = new Vector2(carSpeed, 0);
        carRigidbody.velocity = carVelocity;

        Destroy(gameObject, lifeTime);
    }
}
