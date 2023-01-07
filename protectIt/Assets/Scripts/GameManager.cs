using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
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
    private bool isOver = false;
    private bool isSceneEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetComponent<EffectControl>().playRandomBGM();
        UI_SoundControl.game_started = true; // 게임 시작 - 기존 오디오 소스 파괴
        StartCoroutine(endGameStarted());
        Time.timeScale = 1;
        game_clear_img = game_clear.GetComponent<Image>();
        high_score = PlayerPrefs.GetFloat("high_score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HeartSystem.Hp <= 0 && !isOver && !TimeText.isArrived)
        {
            gameOver();
            Time.timeScale = 0;
            isOver = true;
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
        AudioManager.GetComponent<EffectControl>().playEndingBGM();
        heartUI.SetActive(false);
        game_clear.SetActive(true);
        StartCoroutine(FadeIn()); // fade in
        isSceneEnd = true;
    }

    void gameOver()
    {
        heartUI.SetActive(false);
        AudioManager.GetComponent<EffectControl>().playGameOver(); // play effect sound
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

    public IEnumerator endGameStarted()
    {
        yield return new WaitForSeconds(0.5f);
        UI_SoundControl.game_started = false;
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
            AudioManager.GetComponent<EffectControl>().playGameClear(); // play effect sound
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
