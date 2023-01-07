using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SoundControl : MonoBehaviour
{
    GameObject SoundManager;
    [SerializeField] GameObject BGM_audioSource;
    [SerializeField] GameObject Effect_audioSource;
    AudioSource bgm_audio_source;
    AudioSource effect_audio_source;
    public bool game_started = false;

    private void Awake()
    {
        var objs = FindObjectsOfType<UI_SoundControl>();
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SoundManager = gameObject;
        bgm_audio_source = BGM_audioSource.GetComponent<AudioSource>();
        effect_audio_source = Effect_audioSource.GetComponent<AudioSource>();

        if (bgm_audio_source.isPlaying) return;
        else
        {
            bgm_audio_source.Play();
            DontDestroyOnLoad(SoundManager);
        }
    }

    void Update()
    {
        if (game_started)
        {
            StartCoroutine(destroy_sound());
        }
    }

    public void playEffectAudio()
    {
        effect_audio_source.Play();
    }

    public IEnumerator destroy_sound()
    {
        bgm_audio_source.Stop();
        yield return new WaitForSeconds(2f);
        Destroy(SoundManager);
    }
}