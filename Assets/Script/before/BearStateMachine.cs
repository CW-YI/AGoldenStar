using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearStateMachine : EnemyStateMachine
{
    private EnemyNum num;
    void Start()
    {
        base.life = 5;
        num = GameObject.Find("EnemyNum").GetComponent<EnemyNum>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            base.life = base.GetDamage();
            if (base.IsDeath())
            {
                base.DeathBear();
                num.bearNum--;
            }
        }
    }
}
