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
                text.text = string.Format("{0}�� ����Ͽ� �����ϱ�", PlayerPrefs.GetString("JumpKey"));
                break;

            case InfoType.Attack:
                text.text = string.Format("{0}�� ����Ͽ� �����ϱ�\n{1}�� �����Ű�� ����Ͽ� �ϴ� �����ϱ�", PlayerPrefs.GetString("AttackKey"), PlayerPrefs.GetString("AttackKey"));
                break;

            case InfoType.Crouch:
                text.text = string.Format("{0}�� ����Ͽ� ��ũ����\n{1}�� ������Ű�� ����Ͽ� ��ũ���� �ȱ�", PlayerPrefs.GetString("CrouchKey"), PlayerPrefs.GetString("CrouchKey"));
                break;

            case InfoType.Climb:
                text.text = string.Format("{0}�� ������Ű�� ����Ͽ� ����������", PlayerPrefs.GetString("ClimbKey"));
                break;

            case InfoType.Interaction:
                text.text = string.Format("{0}�� ����Ͽ� �� �����ϱ�\n���� �����ϱ�/���� Ȯ���ϱ�", PlayerPrefs.GetString("InteractionKey"));
                break;
        }
    }
}
