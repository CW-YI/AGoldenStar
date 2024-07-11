using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontJump : MonoBehaviour
{
    public PlayerMoveMent movement;
    public GameObject bearRun;
    public Sprite angryBear1;
    public Sprite angryBear2;
    SpriteRenderer sprite;
    Coroutine alreadyCoru;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.isJump && alreadyCoru == null)
        {
            alreadyCoru = StartCoroutine(Angry_Bear());
        }
    }

    public IEnumerator Angry_Bear()
    {
        sprite.sprite = angryBear1;
        yield return new WaitForSeconds(0.25f);
        sprite.sprite = angryBear2;
        yield return new WaitForSeconds(0.25f);
        bearRun.SetActive(true);
        gameObject.SetActive(false);
    }
}
