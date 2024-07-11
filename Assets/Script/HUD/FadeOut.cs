using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Image image;
    public float fadeSpeed = 0.8f;
    public PlayerMoveMent playerMM;
    public BrightofStar star;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        StartCoroutine(Fade());
    }

    private void OnEnable()
    {
        StartCoroutine(Fade());
    }
    void Update()
    {

    }

    IEnumerator Fade()
    {
        float alpha = 0f;
        playerMM.isStun = true;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * (1.0f / fadeSpeed);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        star.EndingRestart();
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Fade2());
    }

    IEnumerator Fade2()
    {
        float alpha = 1f;
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
