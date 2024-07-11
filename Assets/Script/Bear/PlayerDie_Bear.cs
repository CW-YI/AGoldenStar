using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie_Bear : MonoBehaviour
{
    public PlayerStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BearObstacle")
        {
            stateMachine.playerLife = 0;
            PlayerPrefs.SetInt("PlayerHP", stateMachine.playerLife);
            stateMachine.ChangeLifeUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BearObstacle")
        {
            stateMachine.playerLife = 0;
            PlayerPrefs.SetInt("PlayerHP", stateMachine.playerLife);
            stateMachine.ChangeLifeUI();
        }
    }
}
