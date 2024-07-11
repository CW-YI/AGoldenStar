using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoText : MonoBehaviour
{
    public enum InfoType { Move, Jump, Attack, Crouch, Climb, Interaction }
    public InfoType type;
    Text text;
    void Awake()
    {
        text = GetComponent<Text>();
        TextTuto();
    }

    // Update is called once per frame
    void LateUpdate()
    {
       

    }

    void TextTuto()
    {
        switch (type)
        {
            //case InfoType.Move:
            //    text.text = string.Format("{}")
            //    break;

            case InfoType.Jump:
                text.text = string.Format("{0}을 사용하여 점프하기", PlayerPrefs.GetString("JumpKey"));
                break;

            case InfoType.Attack:
                text.text = string.Format("{0}을 사용하여 공격하기\n{1}과 ↓방향키를 사용하여 하단 공격하기", PlayerPrefs.GetString("AttackKey"), PlayerPrefs.GetString("AttackKey"));
                break;

            case InfoType.Crouch:
                text.text = string.Format("{0}을 사용하여 웅크리기\n{1}과 ←→방향키를 사용하여 웅크리고 걷기", PlayerPrefs.GetString("CrouchKey"), PlayerPrefs.GetString("CrouchKey"));
                break;

            case InfoType.Climb:
                text.text = string.Format("{0}와 ↑↓방향키를 사용하여 오르내리기", PlayerPrefs.GetString("ClimbKey"));
                break;

            case InfoType.Interaction:
                text.text = string.Format("{0}을 사용하여 별 수집하기\n던전 입장하기/지도 확인하기", PlayerPrefs.GetString("InteractionKey"));
                break;
        }
    }
}
