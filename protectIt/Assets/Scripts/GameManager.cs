using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject AudioManager;
    [SerializeField] GameObject[] ending; // ���� �Ϸ���Ʈ 3��
    [SerializeField] GameObject fade_panel;
    [SerializeField] GameObject game_clear_popup;
    [SerializeField] GameObject game_over_popup;
    [SerializeField] GameObject[] heart;
    [SerializeField] GameObject heartUI;
    [SerializeField] Text score_txt;
    [SerializeField] Text high_score_txt;

    private Image fade_panel_img;
    private float high_score;
    private float current_score;
    private bool isClear = false;
    private bool isOver = false;
    private bool isSceneEnd = false;
    private bool isFadeOut = false;
    private int ending_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetComponent<EffectControl>().playRandomBGM();
        UI_SoundControl.game_started = true; // ���� ���� - ���� ����� �ҽ� �ı�
        StartCoroutine(endGameStarted());
        fade_panel_img = fade_panel.GetComponent<Image>();
        Time.timeScale = 1;
        high_score = PlayerPrefs.GetFloat("high_score", 999);
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
        if (isSceneEnd && isFadeOut && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (ending_num == 1 || ending_num == 2 || ending_num == 3)
            {
                StartCoroutine(FadeIn());
            }
            isFadeOut = false;
        }
    }

    void gameClear()
    {
        AudioManager.GetComponent<EffectControl>().playEndingBGM(); // ��� ����
        heartUI.SetActive(false); // �÷��̾� ��Ʈ ��Ȱ��ȭ
        StartCoroutine(FadeIn()); // ù �̹��� fade in
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
            fade_panel_img.color = new Color(255, 255, 255, fadeCount);
        }
        //fade_panel_img.color = new Color(255, 255, 255, 0.8f);
        ending_num++;
        isFadeOut = true;
        if (ending_num == 4)
        {
            fade_panel.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public IEnumerator FadeIn()
    {
        float fadeCount = 0;
        while (fadeCount <= 1)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fade_panel_img.color = new Color(255, 255, 255, fadeCount);
        }
        if (ending_num == 0)
        {
            ending[ending_num].SetActive(true);
        } else if (ending_num == 1 || ending_num == 2)
        {
            ending[ending_num - 1].SetActive(false);
            ending[ending_num].SetActive(true);
        } else
        {
            ending[ending_num - 1].SetActive(false);
            game_clear_popup.SetActive(true); // show score board
            setScore();
        }
        StartCoroutine(FadeOut());
    }

    public IEnumerator endGameStarted()
    {
        yield return new WaitForSeconds(0.1f);
        UI_SoundControl.game_started = false;
    }

    void setScore()
    {
        current_score = TimeText.surviveTime;
        heart[HeartSystem.Hp].SetActive(true); // set heart img
        if (current_score < high_score)
        {
            high_score = current_score;
            PlayerPrefs.SetFloat("high_score", high_score); // renew highest score
            PlayerPrefs.Save();
            AudioManager.GetComponent<EffectControl>().playGameClear(); // play effect sound
        }
        score_txt.text = current_score.ToString("N1") + "�� ���� ���� ������ �־����ϴ�!";
        high_score_txt.text = "�ְ� ���: " + high_score.ToString("N1") +"��";
    }

    public void onClickPause()
    {
        Time.timeScale = 0;
    }

    public void onClickResume()
    {
        Time.timeScale = 1;
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
