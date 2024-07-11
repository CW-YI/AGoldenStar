using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSound : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume *= (PlayerPrefs.GetFloat("BGMSound") * 2f);
    }
}
