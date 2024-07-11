using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateMachine : MonoBehaviour
{
    public int playerLife = 5;
    Animator anim;
    Rigidbody2D rigid;
    CapsuleCollider2D collid;
    SpriteRenderer sprite;
    public bool isDie = false;

    float stayDamageTime = 1.5f;
    float lastDamageTime = 0f;

    bool isFrist = true;

    public bool isInvin = false;
    public PlayTime playtime;
    #region lifeUI
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    #endregion
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        collid = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.HasKey("PlayerHP")) playerLife = PlayerPrefs.GetInt("PlayerHP");
        else playerLife = 5; /////////////////////////////////

        if (!PlayerPrefs.HasKey("PlayerDieNum")) PlayerPrefs.SetInt("PlayerDieNum", 0);
    }
    private void Update()
    {
        //Debug.Log(isInvin);
        if (IsPlayerOver() && isFrist)
        {
            StartCoroutine(GameOver());
            isFrist = false;
        }
        ChangeLifeUI();
    }
    bool IsPlayerOver()
    {
        if (playerLife <= 0)
        {
            isDie = true;
            return true;
        }
        else return false;
    }
    public void ChangeLifeUI()
    {
        if (playerLife <= 4) life1.SetActive(false);
        if (playerLife <= 3) life2.SetActive(false);
        if (playerLife <= 2) life3.SetActive(false);
        if (playerLife <= 1) life4.SetActive(false);
        if (playerLife <= 0) life5.SetActive(false);
    }
    IEnumerator GameOver()
    {
        if (rigid != null) Destroy(rigid); 
        //if (collid != null) Destroy(collid);
        transform.localScale = new Vector3(transform.localScale.x * 0.6f, transform.localScale.y * 0.6f, 0.6f);
        //Debug.Log(transform.localScale);
        anim.SetBool("isDie", true);

        yield return new WaitForSeconds(2.5f);
        PlayerPrefs.SetInt("PlayerDieNum", PlayerPrefs.GetInt("PlayerDieNum") + 1);
        Debug.Log("Á×Àº È½¼ö : " + PlayerPrefs.GetInt("PlayerDieNum"));
        playtime.SavePlayTime();
        SceneManager.LoadScene(2);
    }
    
    public void MinusLife()
    {
        sprite.material.color = new Color(1f, 0.5f, 0.5f, 1f);
        playerLife -= 1;
        PlayerPrefs.SetInt("PlayerHP", playerLife);
        Debug.Log(playerLife);
        ChangeLifeUI();
        Invoke(nameof(ChangeOriginColor), 0.3f);
    }

    void ChangeOriginColor()
    {
        sprite.material.color = new Color(1f, 1f, 1f, 1f);
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy") && Time.time - lastDamageTime > stayDamageTime && !isInvin)
        {
            lastDamageTime = Time.time;
            Debug.Log("onTriggerStay");
            MinusLife();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if ((collision.gameObject.tag == "Obstacle") && Time.time - lastDamageTime > stayDamageTime && !isInvin)
        {
            lastDamageTime = Time.time;
            Debug.Log("onCollisionStay");
            MinusLife();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Poision" && Time.time - lastDamageTime > stayDamageTime)
        {
            lastDamageTime = Time.time;
            Debug.Log("onTriggerEnter");
            MinusLife();
        }
    }
}
