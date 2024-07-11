using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceOpen : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D collid;
    public GameObject EntranceUI;
    bool player_wayin = false;
    void Awake()
    {
        collid = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_wayin && PlayerPrefs.GetInt("PlayerStar") == 5)
        {
            player_wayin = true;
            collid.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerPrefs.GetInt("PlayerStar") < 5)
        {
            EntranceUI.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && PlayerPrefs.GetInt("PlayerStar") < 5)
        {
            EntranceUI.SetActive(false);
        }
    }
}
