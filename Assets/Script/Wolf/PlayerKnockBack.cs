using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    public PlayerMoveMent playerMM;
    public PlayerStateMachine stateMachine;
    public Rigidbody2D rigid;
    public WolfStateMachine wolfState;
    public GameObject stun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !playerMM.isStun && !wolfState.isDie && stateMachine.playerLife > 0)
        {
            playerMM.isStun = true;
            int direction = transform.localScale.x > 0 ? 1 : -1;
            rigid.velocity = new Vector2(20f * direction, -1f);
            stun.SetActive(true);
            Invoke(nameof(StunOff), 1f);
        }
    }

    void StunOff()
    {
        playerMM.isStun = false;
        stun.SetActive(false);
    }
}
