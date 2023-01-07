using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeText : MonoBehaviour
{
    public GameObject Player;
    public Text timeText;
    public static float surviveTime;
    public static bool isArrived;
    void Start()
    {
        surviveTime = 0;
        isArrived = false;
    }

    void Update()
    {
        //하트가 0개면 비활성화
        //도착지점에 닿으면 시간 정지
        
        //if(하트 0개){
        //    timeText.SetActive(false);
        //}
        if(isArrived == false){
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + surviveTime.ToString("N1");
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Destination"){
            isArrived = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); 
        }
    }
}