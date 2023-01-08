using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm_audio_source;
    [SerializeField] AudioSource effect_audio_source;
    [SerializeField] AudioClip ui_click;
    [SerializeField] AudioClip ui_close;
    [SerializeField] AudioMixer mixer;
    [SerializeField] GameObject fade_panel;
    [SerializeField] GameObject[] start;
    [SerializeField] GameObject btn;

    private Image fade_panel_img;
    private int start_num = 0;
    private bool isFadeOut = false;
    private bool isStart = false;

    private void Start()
    {
        effect_audio_source.clip = ui_click;
        mixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGMVolume", 0.75f)) * 20);
        mixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume", 0.75f)) * 20);
        fade_panel_img = fade_panel.GetComponent<Image>();
    }
    private void Update()
    {
        if (isStart && isFadeOut && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (start_num == 1 || start_num == 2 || start_num == 3)
            {
                StartCoroutine(FadeIn());
            }
            isFadeOut = false;
        }
    }

    public void onClickStart()
    {
        fade_panel.SetActive(true);
        btn.SetActive(false);
        isStart = true;
        StartCoroutine(FadeIn());
    }

    public void onPopUpClose()
    {
        effect_audio_source.clip = ui_close;
        effect_audio_source.Play();
    }

    public void onBtnClick()
    {
        effect_audio_source.clip = ui_click;
        effect_audio_source.Play();
    }

    public void OnQuitBtn()
    {
        Application.Quit();
    }

    public void onSkipBtn()
    {
        SceneManager.LoadScene("Map");
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
        start_num++;
        isFadeOut = true;
        if (start_num == 4)
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
        if (start_num == 0)
        {
            start[start_num].SetActive(true);
        }
        else if (start_num == 1 || start_num == 2)
        {
            start[start_num - 1].SetActive(false);
            start[start_num].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Map");
        }
        StartCoroutine(FadeOut());
    }
}
