using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStateMachine : MonoBehaviour
{
    int life = 3;
    public bool isDie = false;
    Animator anim;
    Rigidbody2D rigid;
    EdgeCollider2D collier;
    AudioSource snakeSound;
    public GameObject snakeCollider;
    public GameObject snakeAttack;
    public SnakeMovement movement;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collier = GetComponent<EdgeCollider2D>();
        snakeSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Debug.Log(life);
    }

    void SnakeDie()
    {
        isDie = true;
        anim.SetTrigger("IsSnakeDie");
        Destroy(rigid);
        Destroy(collier);
        Destroy(snakeSound);
        gameObject.GetComponent<SnakeMovement>().enabled = false;
        snakeCollider.SetActive(false);
        snakeAttack.SetActive(false);
        //Invoke("SetFalse", 1f);
    }
    void SetFalse()
    {
        gameObject.SetActive(false);
    }
        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            life -= 1;
            movement.Stun();
            if (life <= 0 && !isDie) SnakeDie();
        }
    }
}
