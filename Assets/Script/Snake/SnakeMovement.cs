using System.Collections;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public bool chasePlayer = false;
    bool isChasePossible = true;
    bool isCorutine = false;
    int nextMove;
    GameObject player;
    Rigidbody2D rigid;
    Animator anim;
    float moveSpeed = 4f;
    float followDistance = 10f;
    public SnakeStateMachine stateMachine;
    Vector3 snakePosition;
    RaycastHit2D hit;
    Vector3 frontPosition;
    RaycastHit2D hitFront;
    public bool playerGetStar = false;
    public bool playerNear = false;
    bool isStun = false;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        Think();
    }

    private void Update()
    {
        if(!playerGetStar) PlayerGetStar();
        //Debug.Log(gameObject.name +" chase Player : "+ chasePlayer + " isChasePossible " + isChasePossible);
        if (!stateMachine.isDie || !isStun)
        {
            DrawRaycast();
            //Debug.Log("gameObject : " + gameObject.name + "hitFront : " + hitFront.collider.name);
            if (hit.collider == null || hitFront.collider != null)
            {
                isChasePossible = false; chasePlayer = false;// 앞에 벽이 있다면 false
                StartCoroutine(ChasePossible());
                nextMove *= -1;
                CancelInvoke();
                Invoke("Think", 3f);
            }
            else if (!isCorutine)
            {
                isChasePossible = true;
                if (isChasePossible) ChasePlayer();
            }
            if (!playerGetStar) anim.SetBool("IsSnakeAttack", playerNear);

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStun)
        {
            if (chasePlayer)
            {
                rigid.velocity = new Vector2(nextMove * moveSpeed * 2f, rigid.velocity.y);
                transform.localScale = new Vector3(nextMove * -1f, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                rigid.velocity = new Vector2(nextMove * moveSpeed, rigid.velocity.y);
                transform.localScale = new Vector3(nextMove * -1f, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void PlayerGetStar()
    {
        GameObject star = GameObject.Find("starPiece");
        if (star == null)
        {
            playerGetStar = true;
            anim.SetBool("IsSnakeAttack", true);
        }
    }

    IEnumerator ChasePossible()
    {
        isCorutine = true;
        yield return new WaitForSeconds(0.8f);
        isCorutine = false;
    }

    void DrawRaycast()
    {
        snakePosition = new Vector3(transform.position.x + nextMove * 3f, transform.position.y - 3f, transform.position.z);
        Debug.DrawRay(snakePosition, Vector2.down * 4, new Color(0, 1, 0));
        hit = Physics2D.Raycast(snakePosition, Vector2.down * 4, 4f, LayerMask.GetMask("Ground"));

        frontPosition = new Vector3(transform.position.x + nextMove * 2f, transform.position.y - 2f, transform.position.z);
        Debug.DrawRay(frontPosition, Vector2.right * nextMove * 2.5f, new Color(0, 1, 0));
        hitFront = Physics2D.Raycast(frontPosition, Vector2.right * nextMove * 2.5f, 2.5f, LayerMask.GetMask("Ground"));
    }

    void ChaseDrawRaycast()
    {
        //nextMove *= -1;
        snakePosition = new Vector3(transform.position.x + nextMove * 3f, transform.position.y - 3f, transform.position.z);
        Debug.DrawRay(snakePosition, Vector2.down * 4, new Color(0, 1, 0));
        hit = Physics2D.Raycast(snakePosition, Vector2.down * 4, 4f, LayerMask.GetMask("Ground"));

        frontPosition = new Vector3(transform.position.x + nextMove * 2f, transform.position.y - 2f, transform.position.z);
        Debug.DrawRay(frontPosition, Vector2.right * nextMove * 2.5f, new Color(0, 1, 0));
        hitFront = Physics2D.Raycast(frontPosition, Vector2.right * nextMove * -2.5f, 2.5f, LayerMask.GetMask("Ground"));
    }
    void Think()
    {
        nextMove = Random.Range(-1, 2);
        while (nextMove == 0) nextMove = Random.Range(-1, 2);
        float nextTime = Random.Range(2f, 5f);
        Invoke("Think", nextTime);
    }

    void ChasePlayer()
    {
        if (player == null)
        {
            Debug.Log("플레이어를 찾을 수 없음");
        }
        else
        {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < followDistance * 2f && Mathf.Abs(transform.position.y - player.transform.position.y) < 4f)
            {
                chasePlayer = true;
                playerNear = true;
                if (!(Mathf.Abs(transform.position.x - player.transform.position.x) < 5f))
                {
                    if (transform.position.x > player.transform.position.x) nextMove = -1;
                    else nextMove = 1;
                    //nextMove = direction;
                }
                ChaseDrawRaycast();
            }
            else
            {
                chasePlayer = false;
                playerNear = false;
            }
        }
    }

    public void Stun()
    {
        //rigid.velocity = new Vector2(5 * nextMove * -1, 5);
        rigid.velocity = new Vector2(nextMove * -4.5f, rigid.velocity.y * 1.5f);
        isStun = true;
        Invoke("isStunFalse", 0.25f);
    }

    void isStunFalse()
    {
        isStun = false;
    }
}
