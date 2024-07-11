using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public GameObject Player;
    public PlayerStateMachine StateMachine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerRespawn()
    {
        Player.transform.position = respawn.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (StateMachine.playerLife > 1) { PlayerRespawn(); }//Invoke("PlayerRespawn", 0.5f);}
        }
    }
}
