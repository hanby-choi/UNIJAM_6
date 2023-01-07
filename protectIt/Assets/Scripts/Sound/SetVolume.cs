using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    string object_name;

    // Start is called before the first frame update
    void Start()
    {
        object_name = this.gameObject.name;
        if (object_name.Equals("BGMSlider"))
        {
            slider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        }
        else if (object_name.Equals("EffectSlider"))
        {
            slider.value = PlayerPrefs.GetFloat("EffectVolume", 0.75f);
        }
    }

    public void SetLevel()
    {
        if (object_name.Equals("BGMSlider"))
        {
            mixer.SetFloat("BGMVolume", Mathf.Log10(slider.value) * 20);
            PlayerPrefs.SetFloat("BGMVolume", slider.value);
        }
        else if (object_name.Equals("EffectSlider"))
        {
            mixer.SetFloat("EffectVolume", Mathf.Log10(slider.value) * 20);
            PlayerPrefs.SetFloat("EffectVolume", slider.value);
        }
        PlayerPrefs.Save();
    }
}
