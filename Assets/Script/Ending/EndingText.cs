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
                text.text = string.Format("���ӿ��� Ƚ�� : {0}ȸ", PlayerPrefs.GetInt("PlayerDieNum"));
                break;

            case InfoType.playTime:
                text.text = string.Format("�÷��� �ð� : {0:F1}��", PlayerPrefs.GetFloat("PlayTime")/60);
                break;
        }
    }
}
