using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitStateMachine : EnemyStateMachine
{
    private EnemyNum num;
    
    void Start()
    {
        base.life = 2;
        num = GameObject.Find("EnemyNum").GetComponent<EnemyNum>();
    }

    // Update is called once per frame
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            base.life = base.GetDamage();
            if (base.IsDeath())
            {
                base.DeathRabbit();
                num.rabbitNum--;
            }
        }
    }
}
