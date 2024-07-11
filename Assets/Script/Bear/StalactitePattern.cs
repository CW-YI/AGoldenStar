using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactitePattern : MonoBehaviour
{
    Rigidbody2D rigid;
    PolygonCollider2D collid;
    AudioSource audioSource;
    public float plusTime = 0f;
    float startTime = 15f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collid = GetComponent<PolygonCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        Invoke("StartPattern", startTime + plusTime * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPattern()
    {
        
        rigid.gravityScale = 2.5f;
    }

    void ExitPattern()
    {
        audioSource.Play();
        //rigid.gravityScale = 0f;
        Destroy(rigid);
        //collid.isTrigger = true;
        Destroy(collid);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ExitPattern();
        }
    }
}
