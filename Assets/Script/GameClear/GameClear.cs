using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class GameClear : MonoBehaviour
{
    public GameObject MainButton;
    public Text text_menu;
    public Text text_end;
    public Text text_playtime;
    public Text text_restart;
    public Image Black;

    void Start()
    {
        PlayerDeletePrefs_GameClear();
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        Color color = Black.color;
        color.a = 1;

        while (color.a > 0)
        {
            color.a -= 0.5f * Time.deltaTime;
            Black.color = color;
            yield return null;
        }

        color.a = 0;
        Black.color = color;
        StartCoroutine(TextFadeIn());
    }
    IEnumerator TextFadeIn()
    {
        yield return new WaitForSeconds(0.5f);
        MainButton.SetActive(true);
        Color color = text_menu.color;
        Color color1 = text_end.color;
        Color color2 = text_playtime.color;
        Color color3 = text_restart.color;

        color.a = color1.a = color2.a = color3.a = 0;

        while (color.a < 1)
        {
            color.a += 1f * Time.deltaTime;
            color1.a += 1f * Time.deltaTime;
            color2.a += 1f * Time.deltaTime;
            color3.a += 1f * Time.deltaTime;
            text_menu.color = color; text_end.color = color1;
            text_playtime.color = color2; text_restart.color = color3;
            yield return null;
        }

        color.a = color1.a = color2.a = color3.a = 1;
        text_menu.color = color; text_end.color = color1;
        text_playtime.color = color2; text_restart.color = color3;
    }
    void PlayerDeletePrefs_GameClear()
    {
        PlayerPrefs.DeleteKey("StartIntro");
        PlayerPrefs.DeleteKey("LoadSave");
        PlayerPrefs.DeleteKey("PlayerHP");
        PlayerPrefs.DeleteKey("PlayerStar");
        PlayerPrefs.DeleteKey("FoxClear");
        PlayerPrefs.DeleteKey("SnakeClear");
        PlayerPrefs.DeleteKey("BearClear");
        PlayerPrefs.DeleteKey("WolfClear");
        PlayerPrefs.DeleteKey("TutorialClear");
        PlayerPrefs.DeleteKey("SavePosition");
    }
}
