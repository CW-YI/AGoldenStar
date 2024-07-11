using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject Maintitle;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject SettingButton;
    public GameObject LoadButton;
    public Text main;
    public Text start;
    public Text exit;
    public Text setting;
    public Text load;
    public Image Black;

    public bool StartPossible = true;

    //public AudioSource dontDestroyBGM;
    
    private void Start()
    {
        OriginSetting();
        LoadButtonColor();
    }
    public void GameStart()
    {
        if (StartPossible)
        {
            PlayerDeletePrefs();
            StartCoroutine(TextFadeIn());
        }
    }
    IEnumerator TextFadeIn()
    {
        Color color = start.color;
        Color color1 = main.color;
        Color color2 = exit.color;
        Color color3 = setting.color;
        Color color4 = load.color;

        color.a = color1.a = color2.a = color3.a = color4.a = 1;

        while (color.a > 0)
        {
            color.a -= 1f * Time.deltaTime;
            color1.a -= 1f * Time.deltaTime;
            color2.a -= 1f * Time.deltaTime;
            color3.a -= 1f * Time.deltaTime;
            color4.a -= 1f * Time.deltaTime;
            start.color = color; main.color = color1;
            exit.color = color2; setting.color = color3; load.color = color4;
            yield return null;
        }

        color.a = color1.a = color2.a = color3.a = color4.a = 0;
        start.color = color; main.color = color1;
        exit.color = color2; setting.color = color3; load.color = color4;
        Maintitle.SetActive(false);
        StartButton.SetActive(false);
        ExitButton.SetActive(false);
        SettingButton.SetActive(false);
        LoadButton.SetActive(false);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Color color = Black.color;
        color.a = 0;

        while (color.a < 1)
        {
            color.a += 1f * Time.deltaTime;
            Black.color = color;
            yield return null;
        }

        color.a = 1;
        Black.color = color;
        //StartCoroutine(StarFadeIn());
        Invoke(nameof(MoveGameScene), 1f);
    }


    void MoveGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GameSetting()
    {
        //
    }

    void LoadButtonColor()
    {
        if (!PlayerPrefs.HasKey("StartIntro") || PlayerPrefs.GetInt("StartIntro") == 1)
        {
            Color color = load.color;
            color.a = 0.5f;
            load.color = color;
        }
        else if (PlayerPrefs.GetInt("StartIntro") == 0)
        {
            Color color = load.color;
            color.a = 1f;
            load.color = color;
        }
    }
    public void GamdLoad()
    {
        //if (!PlayerPrefs.HasKey("StartIntro") || PlayerPrefs.GetInt("StartIntro") == 1)
        //{
        //    //
        //}
        if (PlayerPrefs.GetInt("StartIntro") == 0)
        {
            PlayerPrefs.SetInt("LoadSave", 1);
            BGMContinue bgmcontinue = FindObjectOfType<BGMContinue>();
            if (bgmcontinue != null) { bgmcontinue.BGMStop(); }
            MoveGameScene();
        }
    }
    public void GameExit()
    {
        //PlayerPrefs.DeleteAll();
        Application.Quit();
    }
   
    void OriginSetting()
    {
        if (!PlayerPrefs.HasKey("RunKey")) PlayerPrefs.SetString("RunKey", "left shift");
        if (!PlayerPrefs.HasKey("JumpKey")) PlayerPrefs.SetString("JumpKey", "space");
        if (!PlayerPrefs.HasKey("ClimbKey")) PlayerPrefs.SetString("ClimbKey", "z");
        if (!PlayerPrefs.HasKey("CrouchKey")) PlayerPrefs.SetString("CrouchKey", "c");
        if (!PlayerPrefs.HasKey("InteractionKey")) PlayerPrefs.SetString("InteractionKey", "a");
        if (!PlayerPrefs.HasKey("AttackKey")) PlayerPrefs.SetString("AttackKey", "left ctrl");
        //if (!PlayerPrefs.HasKey("RollKey")) PlayerPrefs.SetString("RollKey", "x");
    }
    void PlayerDeletePrefs()
    {
        PlayerPrefs.DeleteKey("PlayTime");
        PlayerPrefs.DeleteKey("PlayerDieNum");
        PlayerPrefs.DeleteKey("StartIntro");
        PlayerPrefs.DeleteKey("PlayerHP");
        PlayerPrefs.DeleteKey("PlayerStar");
        PlayerPrefs.DeleteKey("FoxClear");
        PlayerPrefs.DeleteKey("SnakeClear");
        PlayerPrefs.DeleteKey("BearClear");
        PlayerPrefs.DeleteKey("WolfClear");
        PlayerPrefs.DeleteKey("TutorialClear");
        PlayerPrefs.DeleteKey("SavePosition");
        PlayerPrefs.DeleteKey("LoadSave");
        PlayerPrefs.DeleteKey("LastStar");
    }

}
