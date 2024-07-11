using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToFox : MonoBehaviour
{
    public Interaction interaction;
    bool playerLocationHere = false;
    public PlayTime playtime;

    public UIMoveScene moveScene;
    public GameObject back;
    public GameObject FoxTitle;
    public GameObject FoxExplain;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject alreadyClear;

    public PlayerMoveMent moveMent;

    bool isOn = false;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("FoxClear"))
        {
            PlayerPrefs.SetInt("FoxClear", 0);
        }
    }
    private void Update()
    {
        if (interaction.isInteraction && PlayerPrefs.GetInt("FoxClear") == 0 && playerLocationHere) SceneExplain();
        if (interaction.isInteraction && PlayerPrefs.GetInt("FoxClear") != 0 && playerLocationHere) AlreadyClear();
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
    void AlreadyClear()
    {
        alreadyClear.SetActive(true);
        Invoke(nameof(OffUI), 2f);
    }
    void OffUI()
    {
        alreadyClear.SetActive(false);
    }

    void SceneExplain()
    {
        moveScene.moveScene = 4;
        isOn = true;
        moveMent.isStun = true;
        back.SetActive(true);
        FoxTitle.SetActive(true);
        FoxExplain.SetActive(true);
        YesButton.SetActive(true);
        NoButton.SetActive(true);
    }

    public void ExitExplain()
    {
        isOn = false;
        moveMent.isStun = false;
        back.SetActive(false);
        FoxTitle.SetActive(false);
        FoxExplain.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
    }

    public void LoadScene()
    {
        PlayerPrefs.SetInt("SavePosition", 1);
        //PlayerPrefs.SetInt("LoadSave", 1);
        PlayerPrefs.SetInt("LastStar", PlayerPrefs.GetInt("PlayerStar"));
        playtime.SavePlayTime();
        SceneManager.LoadScene(4);
    }
}
