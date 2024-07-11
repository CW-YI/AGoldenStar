using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    bool isClimbKeyDown;
    bool isClimbPossible = false;
    //private bool isAttack = true;

    //public PlayerStateMachine playerState;


    float moveSpeed = 15f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, MaxDistance, LayerMask.GetMask("Wall"));
        //Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, LayerMask.GetMask("Wall"));

        //if (hit) Debug.Log(hit.collider.name);

        if (isClimbPossible)
        {
            isClimbKeyDown = Input.GetKey(PlayerPrefs.GetString("ClimbKey"));
            if (isClimbKeyDown) anim.SetBool("isClimb", true);
            else anim.SetBool("isClimb", false);


            if (Input.GetButtonUp("Vertical") && isClimbKeyDown)
            {
                //float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                rigid.velocity = new Vector2(rigid.velocity.normalized.x, rigid.velocity.y * 0.5f);
                //transform.position += new Vector3(rigid.velocity.x, y, 0) * moveSpeed * Time.deltaTime;
                
            }
        }
        //if(Input.GetKeyUp(KeyCode.Z)) 
    }

    void FixedUpdate()
    {
        if (isClimbKeyDown && isClimbPossible)
        {
            float y = Input.GetAxisRaw("Vertical");

            float maxSpeed = 20;
            if (y == 1) moveSpeed = 1.5f;
            else moveSpeed = 0f;

            rigid.AddForce(Vector2.up * y * moveSpeed, ForceMode2D.Impulse);
            //Vector2 moveVelocity = new Vector2(rigid.velocity.x, y) * maxSpeed * Time.deltaTime;

            if (rigid.velocity.y > maxSpeed) rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
            else if (rigid.velocity.y < maxSpeed * (-1)) rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") isClimbPossible = true;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") isClimbPossible = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isClimbPossible = false;
            anim.SetBool("isClimb", false);
        }
    }
}
