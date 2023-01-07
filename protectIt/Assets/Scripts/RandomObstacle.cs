using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    public GameObject[] Obstacles;
    private int randomNumber;

    void Start()
    {
        for(int i = 1; i <= 5; i++){
            randomNumber = Random.Range(1, 10);
            
            if(Obstacles[randomNumber] == null) i--;        //이미 선택했던 오브젝트인 경우(null인 경우), 횟수를 세지 않은 거로 간주(i--)
            else{
                //비활성화 후 그 배열 값을 null로 설정
                Obstacles[randomNumber].SetActive(true);
                Obstacles[randomNumber] = null;
            }
        }

    }
}
