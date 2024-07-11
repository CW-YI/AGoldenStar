using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider bgm;
    public Slider sfx;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("BGMSound")) PlayerPrefs.SetFloat("BGMSound", 0.5f);
        if (!PlayerPrefs.HasKey("SFXSound")) PlayerPrefs.SetFloat("SFXSound", 0.5f);
    }

    private void OnEnable()
    {
        bgm.value = PlayerPrefs.GetFloat("BGMSound");
        sfx.value = PlayerPrefs.GetFloat("SFXSound");
    }
    public void BGMSlider(float value)
    {
        PlayerPrefs.SetFloat("BGMSound", value);
    }

    public void SFXSlider(float value2)
    {
        PlayerPrefs.SetFloat("SFXSound", value2);
    }
}
