using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;
    public float increaseRate;      //이속 증가율
    public float itemDelayTime;     //아이템 지속시간(B타입에만 해당)
    private bool isEffective;       //아이템 효과가 나타나는지 여부
    private bool isCrashed;         //아이템이 닿았는지 여부

    void Start()
    {
        isEffective = false;
        isCrashed = false;
    }

    void Update()
    {
        if(isCrashed == true){                      //아이템과 충돌하면
            isEffective = true;                     //아이템 효과 발생 처리
            StartCoroutine(OnTriggerEnter2D());     //coroutine 시작
            isCrashed = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(isEffective == false){
            if(other.tag == "Item_A"){
                other.gameObject.SetActive(false);
                if(HeartSystem.Hp < 3){
                    HeartSystem.Hp++;
                    player.GetComponent<HeartSystem>().setHeart();
                }
            }

            if(other.tag == "Item_B"){
                other.gameObject.SetActive(false);  //닿은 아이템 비활성화
                
                player.GetComponent<PlayerMovement>().playerVelocity = player.GetComponent<PlayerMovement>().playerVelocity * increaseRate;  //이동속도 증가(효과)
                isCrashed = true;                   //충돌 처리
                Debug.Log("인식됨.");
            }
        }
    }

    IEnumerator OnTriggerEnter2D(){
        yield return new WaitForSeconds(itemDelayTime); //일정 시간 대기
        isEffective = false;                            //아이템 효과 없어짐 처리
        player.GetComponent<PlayerMovement>().playerVelocity = player.GetComponent<PlayerMovement>().playerVelocity / increaseRate;           //이동속도 복원
    }
}

// Item과 충돌하면 비활성화
// 각자의 효과를 얻게됨.

//B 타입 아이템 -> 이속 몇 초간 30% 증가
//GameObject.Find("Character").GetComponent<PlayerMovement>().playerVelocity