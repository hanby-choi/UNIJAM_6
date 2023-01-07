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
    [SerializeField] Text score_txt;
    [SerializeField] Text high_score_txt;

    private Image game_clear_img;
    private int high_score;
    private int current_score;
    private bool isClear = false;

    // Start is called before the first frame update
    void Start()
    {
        game_clear_img = game_clear.GetComponent<Image>();
        high_score = PlayerPrefs.GetInt("high_score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            game_clear_popup.SetActive(true); // show score board
            setScore();
            StartCoroutine(FadeOut()); // fade out
        }
    }

    void gameClear()
    {
        // play effect sound
        game_clear.SetActive(true);
        StartCoroutine(FadeIn()); // fade in
        isClear = true;
    }

    void gameOver()
    {
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
        // set heart img
        if (current_score > high_score)
        {
            high_score = current_score;
            PlayerPrefs.SetInt("high_score", high_score); // renew highest score
            PlayerPrefs.Save();
        }
        score_txt.text = current_score.ToString() + "�� ���� ���� ������ �־����ϴ�!";
        high_score_txt.text = "�ְ� ���: " + high_score.ToString();
    }

    public void onClickRetry()
    {
        SceneManager.LoadScene("Map");
    }

    public void onClickReturn()
    {
        SceneManager.LoadScene("Start");
    }
}
