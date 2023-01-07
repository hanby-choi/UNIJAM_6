using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement2 : MonoBehaviour
{
    public Rigidbody2D carRigidbody2;
    public float carSpeed2;
    public float lifeTime2;
    private Vector2 carVelocity;
    void Start()
    {
        carRigidbody2 = GetComponent<Rigidbody2D>();
        carVelocity = new Vector2(-carSpeed2, 0);
        carRigidbody2.velocity = carVelocity;

        Destroy(gameObject, lifeTime2);
    }
}
