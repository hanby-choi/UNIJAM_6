using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    [SerializeField] AudioSource bgm_audio_source;
    [SerializeField] AudioSource effect_audio_source;
    [SerializeField] AudioClip[] game_bgm;
    [SerializeField] AudioClip ending_bgm;
    [SerializeField] AudioClip gameover_eff;
    [SerializeField] AudioClip gameclear_eff;
    [SerializeField] AudioClip dash_eff;
    [SerializeField] AudioClip heal_eff;
    [SerializeField] AudioClip wind_eff; // flip
    [SerializeField] AudioClip remove_eff; // remove obstacle
    [SerializeField] AudioClip crash_eff;
    [SerializeField] AudioClip ui_eff;

    public void playRandomBGM()
    {
        bgm_audio_source.clip = game_bgm[Random.Range(0,2)];
        bgm_audio_source.Play();
    }

    public void playEndingBGM()
    {
        bgm_audio_source.Stop();
        bgm_audio_source.clip = ending_bgm;
        bgm_audio_source.Play();
    }

    public void playGameOver()
    {
        effect_audio_source.PlayOneShot(gameover_eff);
    }

    public void playGameClear()
    {
        effect_audio_source.PlayOneShot(gameclear_eff);
    }
    public void playDash()
    {
        effect_audio_source.PlayOneShot(dash_eff);
    }
    public void playHealr()
    {
        effect_audio_source.PlayOneShot(heal_eff);
    }
    public void playWind()
    {
        effect_audio_source.PlayOneShot(wind_eff);
    }

    public void playRemove()
    {
        effect_audio_source.PlayOneShot(remove_eff);
    }

    public void playCrash()
    {
        effect_audio_source.PlayOneShot(crash_eff);
    }

    public void playUI()
    {
        effect_audio_source.PlayOneShot(ui_eff);
    }
}
