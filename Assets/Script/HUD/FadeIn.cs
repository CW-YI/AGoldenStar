using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image image;
    public float fadeSpeed = 0.8f;
    public GameObject LoadingText;
    public GameObject LoadingImage;
    public PlayerMoveMent playerMM;

    public AudioSource BGM;
    public AudioSource bearSound;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        StartCoroutine(Fade());
    }

    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        float alpha = 1f;
        playerMM.isStun = true;
        yield return new WaitForSeconds(1.5f);
        LoadingImage.SetActive(false);
        LoadingText.SetActive(false);
        playerMM.isStun = false;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * (1.0f / fadeSpeed);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }

        if (!BGM.isPlaying) BGM.Play();
        if (bearSound != null && !bearSound.isPlaying) bearSound.Play();
        gameObject.SetActive(false);
    }
}
