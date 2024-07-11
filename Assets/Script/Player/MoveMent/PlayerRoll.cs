using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    Animator anim;
    bool isRollKeyDown;
    bool isRollPossible = true;
    bool isRollDelay = true;
    public bool isRoll = false;
    [SerializeField] private float rollDelay = 1.0f;
    public PlayerMoveMent moveMent;
    public PlayerStateMachine stateMachine;
    Rigidbody2D rigid;
    float rollPower = 30f;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRollDelay)
        {
            isRollKeyDown = Input.GetKeyDown(PlayerPrefs.GetString("RollKey"));
            stateMachine.isInvin = true;
        }

        if (moveMent.isClimb || moveMent.isJump)
        {
            isRollPossible = false;
            stateMachine.isInvin = false;
        }
        else isRollPossible = true;

        //Debug.Log("isRollDelay : " + isRollDelay + " isRollKeyDown : " + isRollKeyDown + " isRollPossible : " + isRollPossible);
        if (isRollKeyDown && isRollDelay && isRollPossible)
        {
            anim.SetTrigger("isRoll");
            StartCoroutine(RollTime());
            StartCoroutine(RollDelay());
        }
        else anim.ResetTrigger("isRoll");

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            stateMachine.isInvin = true;
            isRoll = true;
            if (rigid != null) rigid.velocity = new Vector2(transform.localScale.x * rollPower * -1f, 1f);
        }
        else
        {
            isRoll = false;
            Invincible();
            //Invoke("Invincible", 0.6f);
        }
    }
    void Invincible()
    {
        stateMachine.isInvin = false;
    }
    IEnumerator RollDelay()
    {
        isRollDelay = false;
        yield return new WaitForSeconds(rollDelay);
        isRollDelay = true;
    }

    IEnumerator RollTime()
    {
        moveMent.isStun = true;
        yield return new WaitForSeconds(0.3f);
        moveMent.isStun = false;
    }

}
