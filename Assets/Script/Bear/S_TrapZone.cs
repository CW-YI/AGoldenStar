using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TrapZone : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFirst = true;
    public Rigidbody2D rigid;
    AudioSource stoneSound;
    void Start()
    {
        stoneSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isFirst)
        {
            rigid.gravityScale = 10f;
            stoneSound.Play();
            isFirst = false;
        }
    }
}
