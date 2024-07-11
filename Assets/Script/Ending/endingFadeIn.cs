using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingFadeIn : MonoBehaviour
{
    Image image;
    public float fadeSpeed = 0.8f;
    public PlayerMoveMent playerMM;
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
        playerMM.isStun = false;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * (1.0f / fadeSpeed);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
