using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    public GameObject poision;
    GameObject player;
    bool flag = false;
    float poisionDelay = 3f;
    public SnakeMovement movement;
    Coroutine iscorutine;
    bool start = true;
    bool attackPossible = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null) flag = false;
        else flag = true;
    }

    private void Update()
    {
        if (start && movement.playerGetStar && movement.playerNear && attackPossible)
        {
            start = false; SnakeAttackStart();
        }
        if (!start && !movement.playerNear)
        {
            start = true; Invoke("AttackDelay", 3f);
            StopCoroutine(PoisionAttack()); iscorutine = null;
        }
    }
    public void SnakeAttackStart()
    {
        if (flag)
        {
            if (iscorutine == null)
            {
                iscorutine = StartCoroutine(PoisionAttack());
            }
        }
    }
    IEnumerator PoisionAttack()
    {
        while (movement.playerNear)
        {
            attackPossible = false;
            GameObject poisionPref = Instantiate(poision, transform.position, Quaternion.identity);

            Vector3 direction = (player.transform.position - transform.position).normalized;
            poisionPref.GetComponent<Rigidbody2D>().velocity = direction * 25f;

            yield return new WaitForSeconds(poisionDelay);
            attackPossible = true;
        }
    }

    void AttackDelay()
    {
        attackPossible = true;
    }
}
