using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingText : MonoBehaviour
{
    public enum InfoType { playNum, playTime }
    public InfoType type;
    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
        TextTuto();
    }

    void LateUpdate()
    {


    }

    void TextTuto()
    {
        switch (type)
        {
            case InfoType.playNum:
                text.text = string.Format("게임오버 횟수 : {0}회", PlayerPrefs.GetInt("PlayerDieNum"));
                break;

            case InfoType.playTime:
                text.text = string.Format("플레이 시간 : {0:F1}분", PlayerPrefs.GetFloat("PlayTime")/60);
                break;
        }
    }
}
