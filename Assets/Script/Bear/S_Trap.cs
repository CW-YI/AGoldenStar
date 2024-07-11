using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Trap : MonoBehaviour
{
    Rigidbody2D rigid;
    PolygonCollider2D collid;
    bool isFirst = true;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collid = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExitPattern()
    {
        Destroy(rigid);
        //ollid.isTrigger = true;
        Destroy(collid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && isFirst)
        {
            ExitPattern();
        }
    }
}
