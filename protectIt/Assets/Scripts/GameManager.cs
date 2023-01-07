using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject game_clear;
    [SerializeField] GameObject game_clear_popup;
    [SerializeField] GameObject game_over_popup;
    [SerializeField] GameObject[] heart;
    [SerializeField] GameObject heartUI;
    [SerializeField] Text score_txt;
    [SerializeField] Text high_score_txt;

    private Image game_clear_img;
    private float high_score;
    private float current_score;
    private bool isClear = false;
    private bool isSceneEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        game_clear_img = game_clear.GetComponent<Image>();
        high_score = PlayerPrefs.GetFloat("high_score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HeartSystem.Hp <= 0)
        {
            gameOver();
            Time.timeScale = 0;
        }
        if (TimeText.isArrived && !isClear)
        {
            gameClear();
            isClear = true;
        }
        if (isSceneEnd && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            game_clear_popup.SetActive(true); // show score board
            setScore();
            StartCoroutine(FadeOut()); // fade out
        }
    }

    void gameClear()
    {
        heartUI.SetActive(false);
        // play effect sound
        game_clear.SetActive(true);
        StartCoroutine(FadeIn()); // fade in
        isSceneEnd = true;
    }

    void gameOver()
    {
        heartUI.SetActive(false);
        // play effect sound
        game_over_popup.SetActive(true);
    }

    public IEnumerator FadeOut()
    {
        float fadeCount = 1;
        while (fadeCount >= 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            game_clear_img.color = new Color(255, 255, 255, fadeCount);
        }
        game_clear_img.color = new Color(255, 255, 255, 0.8f);
        game_clear.SetActive(false);
        Time.timeScale = 0;
    }

    public IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while (fadeCount <= 1)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            game_clear_img.color = new Color(255, 255, 255, fadeCount);
        }
    }

    void setScore()
    {
        current_score = TimeText.surviveTime;
        heart[HeartSystem.Hp].SetActive(true); // set heart img
        if (current_score > high_score)
        {
            high_score = current_score;
            PlayerPrefs.SetFloat("high_score", high_score); // renew highest score
            PlayerPrefs.Save();
        }
        score_txt.text = current_score.ToString("N1") + "초 만에 집에 데려다 주었습니다!";
        high_score_txt.text = "최고 기록: " + high_score.ToString("N1") +"초";
    }

    public void onClickPause()
    {
        Time.timeScale = 0;
    }

    public void onClickResume()
    {
        Time.timeScale = 1;
        // 효과음 재생
    }

    public void onClickRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map");
    }

    public void onClickReturn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }
}
