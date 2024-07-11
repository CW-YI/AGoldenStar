using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    [SerializeField] private float moveSpeed;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
        moveSpeed = 8;
        
        Invoke("Think", 3);
    }

    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove * moveSpeed, rigid.velocity.y);
        //Debug.Log(transform.name);
        //if (transform.position.x < player.transform.position.x) transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
        //else transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        if (nextMove == -1) transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        else if (nextMove == 1) transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        while (nextMove == 0 && moveSpeed > 5) nextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundSide") nextMove *= -1;

        if (collision.tag == "PlayerAttack")
        {
            int direction = player.transform.localScale.x > 0 ? 1 : -1;
            //Debug.Log(direction);
            nextMove = 0;
            CancelInvoke();
            rigid.velocity = new Vector2(5 * direction * -1, 5);
            Invoke("Think", 0.5f);
        }

    }
}
