using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    int countAttack = 0;
    public GameObject nextCave;
    public GameObject totalCave;
    public Round round;
    public GameObject attackInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeCave()
    {
        if (nextCave != null) nextCave.SetActive(true);
        else if (nextCave == null && totalCave.activeSelf) {
            round.stageClear = true;
            totalCave.SetActive(false);
        }
        if (attackInfo != null) attackInfo.SetActive(false);
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "PlayerAttack")
        {
            ChangeCave();
        }
    }
}
