using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [HideInInspector] public int life;
    //[HideInInspector] public int AttackPower;
    public GameObject player;
    public EnemyStateMachine()
    {
        
    }
    public void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void Update()
    {
        
    }
    public int GetDamage()
    {
        life = life - 1;
        return life;
    }

    void EnemyAttack()
    {
        //player.GetDamage();
    }
    public bool IsDeath()
    {
        if (life <= 0) return true;
        else return false;
    }

    public void DeathRabbit()
    {
        Destroy(gameObject);
    }

    public void DeathBear()
    {
        //Debug.Log(BearNum);
        Destroy(gameObject);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "PlayerAttack")
    //    {
    //        GetDamage();
    //    }
    //}
}
