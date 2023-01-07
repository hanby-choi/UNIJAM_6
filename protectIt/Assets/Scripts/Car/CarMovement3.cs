using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement3 : MonoBehaviour
{
    public Rigidbody2D carRigidbody3;
    public float carSpeed3;
    public float lifeTime3;
    private Vector2 carVelocity;
    void Start()
    {
        carRigidbody3 = GetComponent<Rigidbody2D>();
        carVelocity = new Vector3(0, carSpeed3);
        carRigidbody3.velocity = carVelocity;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        Destroy(gameObject, lifeTime3);
    }

    void Update(){
        if(gameObject.transform.position.y >= -40){
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            carVelocity = new Vector3(-carSpeed3, 0);
            carRigidbody3.velocity = carVelocity;
        }
    }
}

//(16,-40)에 도달하면 rotation을 0으로 회전 후, 속도를 (-~,0)으로 변환