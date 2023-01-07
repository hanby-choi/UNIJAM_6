using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement4 : MonoBehaviour
{
    public Rigidbody2D carRigidbody4;
    public float carSpeed4;
    public float lifeTime4;
    private Vector2 carVelocity;
    void Start()
    {
        carRigidbody4 = GetComponent<Rigidbody2D>();
        carVelocity = new Vector3(0, carSpeed4);
        carRigidbody4.velocity = carVelocity;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        Destroy(gameObject, lifeTime4);
    }

    void Update(){
        if(gameObject.transform.position.y >= -40){
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            carVelocity = new Vector3(-carSpeed4, 0);
            carRigidbody4.velocity = carVelocity;
        }

        if(gameObject.transform.position.x <= 50){
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            carVelocity = new Vector3(0, carSpeed4);
            carRigidbody4.velocity = carVelocity;
        }
        
        if(gameObject.transform.position.y >= -30){
            gameObject.SetActive(false);
        }
    }
}
