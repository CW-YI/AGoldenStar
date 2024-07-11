using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZone : MonoBehaviour
{
    public Rigidbody2D trapRigid;
    bool isfirst = true;
    AudioSource stoneSound;
    // Start is called before the first frame update
    void Awake()
    {
       stoneSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigid.constraints = RigidbodyConstraints2D.None;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isfirst) {stoneSound.Play(); isfirst = false;}
            trapRigid.constraints = RigidbodyConstraints2D.None;
            trapRigid.AddForce(Vector2.down * 1f, ForceMode2D.Impulse);
        }
    }
}
