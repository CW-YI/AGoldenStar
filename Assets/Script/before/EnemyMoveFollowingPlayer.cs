using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFollowingPlayer : MonoBehaviour
{
    public GameObject player; 
    public float followDistance = 100f; 

    private float moveSpeed = 5f; 
    Rigidbody2D rigid;
    float direction;
    bool isFollowingPossible = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingPossible)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < followDistance && isFollowingPossible)
            {
                Vector3 moveDirection = (player.transform.position - transform.position).normalized;
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            rigid.velocity = new Vector2(direction * moveSpeed, rigid.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x < player.transform.position.x) transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        else transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundSide")
        {
            isFollowingPossible = false;
            direction = transform.localScale.x;// * -1;
        }

            if (collision.tag == "PlayerAttack")
        {
            int direction_player = player.transform.localScale.x > 0 ? 1 : -1;
           
            rigid.velocity = new Vector2(5 * direction_player * -1, 5);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "GroundSide") isFollowingPossible = true;
    }
}
