using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbRaycast : MonoBehaviour
{
    Rigidbody2D rigid;
    public PlayerMoveMent moveMent;
    bool isWall = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        Vector3 raycastPositionDown = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
        Vector3 raycastPositionUp = transform.position;
        //Vector3 jumpPosition = transform.position;
        Debug.DrawRay(raycastPositionDown, Vector2.left * transform.localScale.x * (1.5f), new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(raycastPositionDown, Vector2.left * transform.localScale.x * 1.5f, 1.5f, LayerMask.GetMask("Wall"));

        Debug.DrawRay(raycastPositionUp, Vector2.left * transform.localScale.x * (1.5f), new Color(0, 1, 0));
        RaycastHit2D hit2 = Physics2D.Raycast(raycastPositionUp, Vector2.left * transform.localScale.x * 1.5f, 1.5f, LayerMask.GetMask("Wall"));

        //Debug.DrawRay(jumpPosition, Vector2.left * transform.localScale.x * (3f), new Color(0, 1, 0));
        //RaycastHit2D hit3 = Physics2D.Raycast(jumpPosition, Vector2.left * transform.localScale.x * 3f, 3f, LayerMask.GetMask("Wall"));

        //Debug.Log(hit.collider.gameObject.name);
        if (hit.collider != null || hit2.collider != null)
        {
            moveMent.isClimbPossible = true;
            moveMent.isClimbJump = true;
            //moveMent.isJump = false;
            //moveMent.nowJump = 0;
        }
        else
        {
            moveMent.isClimbPossible = false;
            //moveMent.isClimbJump = false;
        }
        //if (hit3.collider != null)
        //{
        //    moveMent.isClimbJump = true;
        //}
        //else if (hit3.collider == null)
        //{
        //    moveMent.isClimbJump = false;
            //isGround = false;
    }
}
