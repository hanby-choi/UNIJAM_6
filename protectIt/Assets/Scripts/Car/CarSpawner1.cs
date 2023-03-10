using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner1 : MonoBehaviour
{
    public GameObject carPrefab1;   // 생성할 차의 원본 프리팹
    public float spawnRate1;     // 차 생성 주기
    private float timeAfterSpawn;       // 최근 생성 시점에서 지난 시간(측정 시간)

    void Start()
    {
        timeAfterSpawn = 0f;        //측정 시간을 0으로 초기화
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate1){
            timeAfterSpawn = 0f;
            
            GameObject car1 = Instantiate(carPrefab1, transform.position, transform.rotation);
        }
    }
}
