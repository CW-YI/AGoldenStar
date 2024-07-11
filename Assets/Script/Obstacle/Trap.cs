using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject trap;
    public Animator animator;
    AudioSource trapSound;
    void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrapSetActive()
    {
        trap.SetActive(true);
        if (trapSound != null && !trapSound.isPlaying) trapSound.Play();
    }

    void TrapSetActiveFalse()
    {
        trap.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke(nameof(TrapSetActive), 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isFinish", true);
            Invoke(nameof(TrapSetActiveFalse), 0.1f);
        }
    }
}
