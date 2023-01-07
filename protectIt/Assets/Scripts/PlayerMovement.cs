using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;  //  이동에 사용할 rigidbody component
    Vector2 playerVelocity; //  player의 속도벡터 선언

    public float playerSpeed;
    public float changeRateMin;    //  최소 방향전환 주기
    public float changeRateMax;   //  최대 방향전환 주기
    private float changeRate;    //  방향전환 주기
    private float timeAfterChange;   //  최근 방향전환 시점에서 지난 시간

    private SpriteRenderer playerSRenderer;  

    void Start()
    {
        playerVelocity = new Vector2(playerSpeed, 0);    //  player의 초기속도 선언
        playerRigidbody = GetComponent<Rigidbody2D>();    //  게임 오브젝트에서 2D Rigidbody component 찾아서 playerRigidbody에 할당
        
        playerRigidbody.velocity = playerVelocity;  //  player의 속도 설정

        timeAfterChange = 0f;
        changeRate = Random.Range(changeRateMin, changeRateMax);    //방향전환 주기 값 설정(Random)

        playerSRenderer = GetComponent<SpriteRenderer>(); //  게임 오브젝트에서  component 찾아서 playerSRenderer에 할당
    }

    
    void Update()
    {
        timeAfterChange += Time.deltaTime;      //  마지막 방향 전환 이후 시간 측정

        /*playerVelocity = Vector2(playerSpeed * transform.forward);
        playerRigidbody.velocity = playerVelocity;  */


        if(timeAfterChange >= changeRate)   //  방향전환 주기보다 클 경우
        {
            timeAfterChange = 0f;
            
            playerVelocity = -playerVelocity;   //방향 전환
            playerRigidbody.velocity = playerVelocity;  //player의 속도 설정

            changeRate = Random.Range(changeRateMin, changeRateMax);    //방향전환 주기 값 재설정

            if(playerVelocity.x > 0) playerSRenderer.flipX = false;    //방향 전환 후 이동방향이 +면 flipX를 false로 설정
            else playerSRenderer.flipX = true;   //방향 전환 후 이동방향이 -면 true로 설정

        }
    }
}
