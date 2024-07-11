using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicWolfMovement : MonoBehaviour
{
    int nextMove;
    float moveSpeed = 5f;
    public Transform player;
    public PlayerStateMachine playerMM;
    public WolfStateMachine wolfState;
    Rigidbody2D rigid;
    PolygonCollider2D collid;
    Vector3 frontPosition;
    RaycastHit2D hitFront;
    Animator anim;
    AudioSource barkSound;

    int life = 15;
    public GameObject hurt;
    bool clear = false;
    bool isStun = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collid = GetComponent<PolygonCollider2D>();
        barkSound = GetComponent<AudioSource>();
        Think();
    }

    private void Update()
    {
        DrawRaycast();
        if (hitFront.collider != null && !clear)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 3f);
        }
        if (wolfState.isDie && !clear)
        {
            clear = true;
            barkSound.Stop();
            gameObject.tag = "Untagged";
            anim.SetBool("die", true);
            Destroy(rigid);
        }
    }
    void FixedUpdate()
    {
        if (!clear) Move();
    }

    private void Move()
    {
        if (!isStun && !clear)
        {
            rigid.velocity = new Vector2(nextMove * moveSpeed, rigid.velocity.y);
            transform.localScale = new Vector3(nextMove * -1f, transform.localScale.y, transform.localScale.z);
        }
    }

    void DrawRaycast()
    {
        frontPosition = new Vector3(transform.position.x + nextMove * 2f, transform.position.y - 2f, transform.position.z);
        Debug.DrawRay(frontPosition, Vector2.right * nextMove * 2.5f, new Color(0, 1, 0));
        hitFront = Physics2D.Raycast(frontPosition, Vector2.right * nextMove * 2.5f, 2.5f, LayerMask.GetMask("wolfGround"));
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        while (nextMove == 0) nextMove = Random.Range(-1, 2);
        float nextTime = Random.Range(2f, 5f);
        if(!clear) Invoke("Think", nextTime);
    }

    void AttackPlayer()
    {
        isStun = true;
        life -= 1;
        if (life <= 0) gameObject.SetActive(false);

        int direction = 1;
        if (player.position.x < transform.position.x) direction = -1;
        nextMove = direction;

        isStun = false;
        CancelInvoke();
        Invoke("Think", 3f);
        StopCoroutine("HurtOffRoutine");
        anim.SetBool("isAttack", false);
        hurt.SetActive(false);
        StartCoroutine("HurtOffRoutine");
    }
    
    IEnumerator HurtOffRoutine()
    {
        anim.SetBool("isAttack", true);
        hurt.SetActive(true);
        playerMM.MinusLife();
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isAttack", false);
        hurt.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack" && !clear)
        {
            AttackPlayer();
        }
    }
}
