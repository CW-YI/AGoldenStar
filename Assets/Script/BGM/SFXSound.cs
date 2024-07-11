using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSound : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume *= (PlayerPrefs.GetFloat("SFXSound") * 2f);
    }
}
