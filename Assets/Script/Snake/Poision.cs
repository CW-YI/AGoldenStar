using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poision : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //Invoke("PoisionPool", 0.3f);
            PoisionPool();
        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "headcollider")
        {
            DestroyPosion();
            //Invoke("DestroyPosion", 0.5f);
        }
    }

    void PoisionPool()
    {
        Destroy(rigid);
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        anim.SetBool("hit_poision", true);
        Invoke("DestroyPosion", 1.5f);
    }

    void DestroyPosion()
    {
        Destroy(gameObject);
    }
}
