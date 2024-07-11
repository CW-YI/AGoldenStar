using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMContinue : MonoBehaviour
{
    private static BGMContinue instance = null;
    AudioSource bgm;
    float fadeoutTime = 2f;
    public static BGMContinue Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        bgm = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator BGMFadeOut()
    {
        float startVolume = bgm.volume;

        while (bgm.volume > 0)
        {
            bgm.volume -= startVolume * Time.deltaTime / fadeoutTime;
            yield return null;
        }

        bgm.Stop();
    }

    public IEnumerator BGMFadeIn()
    {
        Debug.Log("playStart");
        bgm.Play();
        float startVolume = 0.15f;

        while (bgm.volume < 0.15f)
        {
            bgm.volume += startVolume * Time.deltaTime / fadeoutTime;
            yield return null;
        }

        bgm.volume = 0.15f;
    }

    public void BGMStop()
    {
        bgm.Stop();
    }
}
