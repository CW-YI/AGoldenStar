using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRaycast : MonoBehaviour
{
    //public DownAttackJump downAttack;
    public PlayerMoveMent moveMent;
    void Start()
    {
       
    }
    void Update()
    {
        //if (!isGround)
        //{
        //    rigid.velocity = new Vector2(rigid.velocity.x, moveMent.jumpPower * (-1f));
        //}
    }
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        Vector3 leftPosition = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
        Vector3 rightPosition = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
        Debug.DrawRay(position, Vector2.down * 3.2f, new Color(0, 1, 0));
        Debug.DrawRay(leftPosition, Vector2.down * 3.2f, new Color(0, 1, 0));
        Debug.DrawRay(rightPosition, Vector2.down * 3.2f, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down * 3.2f, 3.2f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit1 = Physics2D.Raycast(leftPosition, Vector3.down * 3.2f, 3.2f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit2 = Physics2D.Raycast(rightPosition, Vector3.down * 3.2f, 3.2f, LayerMask.GetMask("Ground"));

        if (hit.collider != null || hit1.collider != null || hit2.collider != null)
        {
            //Debug.Log("¶¥");
            //moveMent.isJumpPossible = true;
            moveMent.isJump = false;
            moveMent.nowJump = 0;
            //moveMent.isClimbJump = false;
            //isGround = true;
        }
        else
        {
            moveMent.isJump = true;
            //isGround = false;
        }
    }
}