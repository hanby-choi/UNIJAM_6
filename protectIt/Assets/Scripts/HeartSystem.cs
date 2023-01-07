using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public int Hp;
    public float delayTime;
    bool isCrashed;
    bool isDelay;
    void Start()
    {
        Hp = 3;
        isCrashed = false;
        isDelay = false;
    }

    
    void Update()
    {
        if(Hp == 0){
            Debug.Log("Game Over");
            //씬 전환 등 몇가지 더
        }

        if(isCrashed == true){
            isDelay = true;
            StartCoroutine(OnTriggerStay2D());
            
            isCrashed = false;
        }
    }

    void OnTriggerStay2D(Collider2D other){         //충돌하는 경우 메소드
        if(isDelay == false){                       //자동차일 때
            if(other.tag == "Car"){
                Hp = Hp - 3;
                isCrashed = true;
                //UI 하트 개수 감소
            }

            if(other.tag == "Obstacle"){            //방해물일 때
                Hp--;
                isCrashed = true;
                //UI 하트 개수 감소
            }
        }   
    }

    IEnumerator OnTriggerStay2D() {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
