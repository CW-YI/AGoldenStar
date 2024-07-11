using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoard : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("board_breaking"))
        {
            gameObject.tag = "GameOver";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(BoardBreak());
        }
    }

    IEnumerator BoardBreak()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isDamaged", true);
    }
}
