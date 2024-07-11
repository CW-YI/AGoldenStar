using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAttackJump : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigid;
    public PlayerMoveMent movement;
    public PlayerAttack attack;
    
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (attack.isAttackJumpPossible)
            {
                if (rigid.velocity.y <= 0) rigid.AddForce(Vector2.up * movement.jumpPower * 1.2f, ForceMode2D.Impulse);
                attack.isAttackJumpPossible = false;
            }


        }
    }
}
