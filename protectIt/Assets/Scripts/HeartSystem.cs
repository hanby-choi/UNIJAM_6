using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] heartUI;
    public static int Hp;
    public float delayTime;
    bool isCrashed;
    bool isDelay;
    void Start()
    {
        Hp = 3;
        isCrashed = false;
        isDelay = false;
        heartUI[Hp].SetActive(true);
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
                setHeart(); //UI 하트 개수 감소
            }

            if(other.tag == "Obstacle"){            //방해물일 때
                Hp--;
                isCrashed = true;
                setHeart(); //UI 하트 개수 감소
            }
        }
    }

    void setHeart()
    {
        for (int i=0; i<4; i++)
        {
            if (i == Hp)
            {
                heartUI[i].SetActive(true);
            } 
            else
            {
                heartUI[i].SetActive(false);
            }
        }
    }

    IEnumerator OnTriggerStay2D() {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
    }
}
