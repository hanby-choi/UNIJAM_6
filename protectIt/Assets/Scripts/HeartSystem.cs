using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
    public GameObject[] heartUI;
    public static int Hp;
    public float delayCount;
    SpriteRenderer spriteRenderer;
    bool isCrashed;
    bool isDelay;

    void Start()
    {
        Hp = 3;
        isCrashed = false;
        isDelay = false;
        heartUI[Hp].SetActive(true);
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if(isCrashed == true){
            AudioManager.GetComponent<EffectControl>().playCrash();
            isDelay = true;
            StartCoroutine(invincibleTime());
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

    public void setHeart()
    {
        for (int i=0; i<4; i++)
        {
            if (i == Hp)
                heartUI[i].SetActive(true);
            else
                heartUI[i].SetActive(false);
        }
    }

    IEnumerator invincibleTime() {
        int countTime = 0;
        while (countTime < delayCount)
        {
            if(countTime % 2 == 0)
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            else
                spriteRenderer.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        isDelay = false;
        yield return null;
    }
}
