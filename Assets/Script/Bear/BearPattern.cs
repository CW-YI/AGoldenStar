using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearPattern : MonoBehaviour
{
    public Sprite sleepImage;
    public Sprite wakeupImage;
    public float patternTime = 5f;
    public float wakeupTime = 2f;

    public GameObject sleepBubble;
    SpriteRenderer sprite;
    AudioSource snoreSound;
    public bool bearStateSleep = true;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        snoreSound = GetComponent<AudioSource>();
        StartCoroutine(BearPatternStart());
    }

    IEnumerator BearPatternStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(patternTime - 1f); //1ÃÊÀü ´«¶ß´Â °Í ¿¹°í
            snoreSound.Stop();
            sleepBubble.SetActive(false); // bubble X

            yield return new WaitForSeconds(1f);
            bearStateSleep = false;
            sprite.sprite = wakeupImage;
            
            yield return new WaitForSeconds(wakeupTime);
            snoreSound.Play();
            bearStateSleep = true;
            sprite.sprite = sleepImage;
            sleepBubble.SetActive(true);
        }
    }
}
