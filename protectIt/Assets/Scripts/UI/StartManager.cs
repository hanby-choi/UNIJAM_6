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

    private void Start()
    {
        effect_audio_source.clip = ui_click;
        mixer.SetFloat("BGMVolume", Mathf.Log10(PlayerPrefs.GetFloat("BGMVolume", 0.75f)) * 20);
        mixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume", 0.75f)) * 20);
    }

    public void onClickStart()
    {
        SceneManager.LoadScene("Map");
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
}
