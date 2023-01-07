using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
    /*bool isCatchable;       //Trigger와의 충돌 여부 확인하는 변수
    void Start()
    {
        isCatchable = false;
    }

    void Update()
    {
        if(isCatchable == true){                            //Trigger와 충돌한 상태이면
            if(Input.GetKey(KeyCode.Space) == true){    //이 상태에서 space bar를 누르면
                .SetActive(false);
            }
        }
    }

    //충돌해 있는 동안 true, 충돌해 있지 않으면 false
    void OnTriggerEnter2D(Collider2D other){        //Trigger와 충돌하면 isCatchable을 true로 설정
        if(other.tag == "Trigger")
            isCatchable = true;
    }

    void OnTriggerExit2D(Collider2D other){         //Trigger로 부터 분리되면 isCatchable을 false로 설정
        if(other.tag == "Trigger")
            isCatchable = false;
    }*/
    void OnTriggerStay2D(Collider2D other){
        if(Input.GetKey(KeyCode.Space) == true){
            if(other.tag == "Trigger"){
                other.gameObject.transform.parent.gameObject.SetActive(false);
                AudioManager.GetComponent<EffectControl>().playRemove();
            }
        }
    }
}
