using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class WolfStateMachine : MonoBehaviour
{
    int wolfHP = 30;
    public bool isDie = false;

    public GameObject ExitWay;
    public CameraController controller;
    //public WolfAttack wolfAttack;
    public PlayerKnockBack knockBack;

    public AudioSource dieSound;

    public Slider wolfHp;
    public GameObject wolfHPSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wolfHp.value = (30f - wolfHP) / 30f;
        //Debug.Log("wolfHPSlider : " + (30 - wolfHP) / 30);
    }
    void WolfDie()
    {
        isDie = true;
        wolfHPSlider.SetActive(false);
        dieSound.Play();
        gameObject.tag = "Untagged";
        ExitWay.SetActive(false);
        controller.enabled = true;
        knockBack.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            wolfHP -= 1;
            Debug.Log("wolfHP : " + wolfHP);
            if (wolfHP <= 0 && !isDie) WolfDie();
        }
    }
}
