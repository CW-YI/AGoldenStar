using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovment : MonoBehaviour
{
    public bool isStop = true;
    int direction = -1;
    public Round round;
    public float foxSpeed = 0.05f;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public GameObject line;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isStop) Run();
        if (round.stageClear)
        {
            foxSpeed = 0.8f;
            line.SetActive(false);
        }
    }
    public void ChangeColor1()
    {
        spriteRenderer.color = new Color(0.25f, 0.29f, 0.22f);
    }
    public void ChangeColor2()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f);
    }

    void Run()
    {
        //Debug.Log(isStop);
        if (round.stage % 2 == 1) direction = -1;
        else direction = 1;
        transform.localScale = new Vector3(direction * -1, 1, 1);
        transform.position = new Vector3(transform.position.x + direction * foxSpeed, transform.position.y, transform.position.z);
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "cave")
        {
            isStop = true;
            round.RoundRestart();
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Finish")
        {
            isStop = true;
            if (round.stage == 4)
            {
                round.stage = 5;
                round.stageClear = false;
                round.RoundStart();
                animator.SetBool("foxEnd", true);
            }
            else gameObject.SetActive(false);
        }
    }
}
