using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToWolf : MonoBehaviour
{
    public Interaction interaction;
    bool playerLocationHere = false;
    public PlayTime playtime;

    public UIMoveScene moveScene;
    public GameObject back;
    public GameObject WolfTitle;
    public GameObject WolfExplain;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject alreadyClear;

    public PlayerMoveMent moveMent;

    bool isOn = false;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("WolfClear"))
        {
            PlayerPrefs.SetInt("WolfClear", 0);
        }
    }

    private void Update()
    {
        if (interaction.isInteraction && PlayerPrefs.GetInt("WolfClear") == 0 && playerLocationHere) SceneExplain();
        if (interaction.isInteraction && PlayerPrefs.GetInt("WolfClear") != 0 && playerLocationHere) AlreadyClear();
        if (isOn)
        {
            //if (Input.GetKeyUp(KeyCode.Escape))
            //{
            //    LoadScene();
            //}
            //else if (Input.GetKeyUp(PlayerPrefs.GetString("InteractionKey")))
            //{
            //    ExitExplain();
            //}
        }
    }
    void AlreadyClear()
    {
        alreadyClear.SetActive(true);
        Invoke(nameof(OffUI), 2f);
    }
    void OffUI()
    {
        alreadyClear.SetActive(false);
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

    void SceneExplain()
    {
        moveScene.moveScene = 7;
        isOn = true;
        moveMent.isStun = true;
        back.SetActive(true);
        WolfTitle.SetActive(true);
        WolfExplain.SetActive(true);
        YesButton.SetActive(true);
        NoButton.SetActive(true);
    }

    public void ExitExplain()
    {
        isOn = false;
        moveMent.isStun = false;
        back.SetActive(false);
        WolfTitle.SetActive(false);
        WolfExplain.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
    }

    public void LoadScene()
    {
        PlayerPrefs.SetInt("SavePosition", 4);
        //PlayerPrefs.SetInt("LoadSave", 1);
        PlayerPrefs.SetInt("LastStar", PlayerPrefs.GetInt("PlayerStar"));
        playtime.SavePlayTime();
        SceneManager.LoadScene(7);
    }
}
