using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
    public Rigidbody2D playerRigidbody;  //  이동에 사용할 rigidbody component
    private SpriteRenderer playerSRenderer; //Xflip에 사용할 객체
    public Vector2 playerVelocity; //  player의 속도벡터
    private Vector2 direction;      //player의 방향벡터
    public float playerSpeed;       // 플레이어 이동 속력
    public float changeRateMin;    //  최소 방향전환 주기
    public float changeRateMax;   //  최대 방향전환 주기
    private float changeRate;    //  방향전환 주기(난수)
    private float timeAfterChange;   //  마지막 방향전환 시점에서 지난 시간(측정 시간)
    public Camera cam;
    private Vector2 dir;

    public float rotationSpeed;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();    //  게임 오브젝트에서 2D Rigidbody component 찾아서 playerRigidbody에 할당
        playerSRenderer = GetComponent<SpriteRenderer>(); //  게임 오브젝트에서  component 찾아서 playerSRenderer에 할당

        playerVelocity = new Vector2(playerSpeed, 0f);    //  player의 초기속도 선언
        playerRigidbody.velocity = playerVelocity;  //  player의 속도 설정

        timeAfterChange = 0f;
        changeRate = Random.Range(changeRateMin, changeRateMax);    //방향전환 주기 값 설정(Random)
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
            playerVelocity = Quaternion.Euler(0, 0, Time.deltaTime * rotationSpeed) * playerVelocity;
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, 0, -Time.deltaTime * rotationSpeed);
            playerVelocity = Quaternion.Euler(0, 0, - Time.deltaTime * rotationSpeed) * playerVelocity;
        }

        timeAfterChange += Time.deltaTime;      //  마지막 방향 전환 이후 시간 측정

        if(timeAfterChange >= changeRate)   //  측정시간이 방향전환 주기보다 클 경우
        {
            playerVelocity = -playerVelocity;  //player의 이동 방향 전환
            playerSRenderer.flipX = !playerSRenderer.flipX;         //player flipX
            AudioManager.GetComponent<EffectControl>().playWind();
            timeAfterChange = 0f;           //  측정시간 0으로 초기화
            changeRate = Random.Range(changeRateMin, changeRateMax);    //방향전환 주기 값 재설정
        }


        playerRigidbody.velocity = playerVelocity;
    }
}