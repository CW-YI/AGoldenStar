using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public enum InfoType {RabbitText, BearText}
    public InfoType type;
    Text myText;

    public EnemyNum num;
    public int rabbitNum = 0;
    public int bearNum = 0;
    void Awake()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.RabbitText:
                rabbitNum = num.rabbitNum;
                myText.text = string.Format("x {0:D2}", rabbitNum);
                break;
            case InfoType.BearText:
                bearNum = num.bearNum;
                myText.text = string.Format("x {0:D2}", bearNum);
                break;
        }

    }
}
