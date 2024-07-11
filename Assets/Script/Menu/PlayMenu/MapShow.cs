using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShow : MonoBehaviour
{
    public Interaction interaction;
    public GameObject full_map;
    public GameObject playerPosition;
    public GameObject playerPosition2;
    public GameObject playerPosition3;
    public GameObject playerPosition4;
    public GameObject playerPosition5;
    public GameObject playerPosition6;
    public GameObject playerPosition7;
    public GameObject playerPosition8;
    public GameObject playerPosition9;
    public PlayerMoveMent playerMM;
    bool playerLocationHere = false;
    public bool isOn = false;
    private void Update()
    {
        if (interaction.isInteraction && playerLocationHere) ShowMap();
        //if (Input.GetKeyUp(KeyCode.Escape) && isOn)
        //{
        //    OffMap();
        //}
    }
    void ShowMap()
    {
        isOn = true;
        playerMM.isStun = true;
        full_map.SetActive(true);
        playerPosition.SetActive(true);
    }

    public void OffMap()
    {
        isOn = false;
        playerMM.isStun = false;
        if (playerPosition != null) playerPosition.SetActive(false);
        if (playerPosition2 != null) playerPosition2.SetActive(false);
        if (playerPosition3 != null) playerPosition3.SetActive(false);
        if (playerPosition4 != null) playerPosition4.SetActive(false);
        if (playerPosition5 != null) playerPosition5.SetActive(false);
        if (playerPosition6 != null) playerPosition6.SetActive(false);
        if (playerPosition7 != null) playerPosition7.SetActive(false);
        if (playerPosition8 != null) playerPosition8.SetActive(false);
        if (playerPosition9 != null) playerPosition9.SetActive(false);
        full_map.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInteraction")
        {
            playerLocationHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerInteraction")
        {
            playerLocationHere = false;
        }
    }
}
