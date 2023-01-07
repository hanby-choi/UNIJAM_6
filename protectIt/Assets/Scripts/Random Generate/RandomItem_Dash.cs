using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem_Dash : MonoBehaviour
{
    public GameObject[] Item_Dash;
    public int item_DashNumber;
    private int randomNumber;

    void Start()
    {
        for(int i = 1; i <= item_DashNumber; i++){
            randomNumber = Random.Range(0, 10);
            
            if(Item_Dash[randomNumber] == null) i--;        //이미 선택했던 오브젝트인 경우(null인 경우), 횟수를 세지 않은 거로 간주(i--)
            else{
                //비활성화 후 그 배열 값을 null로 설정
                Item_Dash[randomNumber].SetActive(true);
                Item_Dash[randomNumber] = null;
            }
        }

    }
}
