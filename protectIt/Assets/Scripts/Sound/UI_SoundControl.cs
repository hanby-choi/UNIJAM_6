using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SoundControl : MonoBehaviour
{
    GameObject SoundManager;
    [SerializeField] GameObject BGM_audioSource;
    //[SerializeField] GameObject Effect_audioSource;
    AudioSource bgm_audio_source;
    AudioSource effect_audio_source;
    public static bool game_started = false;

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
        //effect_audio_source = Effect_audioSource.GetComponent<AudioSource>();

        if (bgm_audio_source.isPlaying) return; // 이미 브금이 재생중이면 스킵
        else // 브금이 나오지 않고 있다면
        {
            bgm_audio_source.Play(); // 브금 재생
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

    public IEnumerator destroy_sound()
    {
        bgm_audio_source.Stop();
        yield return new WaitForSeconds(2f);
        Destroy(SoundManager);
    }
}