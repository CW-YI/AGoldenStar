using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    //public int flag = 0;
    public GameObject fox;
    public GameObject snake;
    public GameObject bear;
    public GameObject wolf;
    public GameObject start;
    void Awake()
    {
        // 플레이 중인 던전 판단
        //if (!PlayerPrefs.HasKey("FoxPosition")) PlayerPrefs.SetInt("FoxPosition", 0);
        //if (!PlayerPrefs.HasKey("SnakePosition")) PlayerPrefs.SetInt("SnakePostion", 0);
        //if (!PlayerPrefs.HasKey("BearPosition")) PlayerPrefs.SetInt("BearPostion", 0);
        //if (!PlayerPrefs.HasKey("WolfPosition")) PlayerPrefs.SetInt("WolfPostion", 0);
        if (!PlayerPrefs.HasKey("SavePosition")) PlayerPrefs.SetInt("SavePosition", 0);
        if (!PlayerPrefs.HasKey("LoadSave")) PlayerPrefs.SetInt("LoadSave", 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        if (PlayerPrefs.GetInt("SavePosition") == 0 && PlayerPrefs.GetInt("LoadSave") == 1)
        {
            PlayerPrefs.SetInt("LoadSave", 0);
            transform.position = start.transform.position;
        }
        if (PlayerPrefs.GetInt("SavePosition") == 1 && PlayerPrefs.GetInt("LoadSave") == 1)
        {
            PlayerPrefs.SetInt("LoadSave", 0);
            transform.position = fox.transform.position;
        }
        if (PlayerPrefs.GetInt("SavePosition") == 2 && PlayerPrefs.GetInt("LoadSave") == 1)
        {
            PlayerPrefs.SetInt("LoadSave", 0);
            //PlayerPrefs.SetInt("SnakePosition", 0);
            transform.position = snake.transform.position;  
        }
        if (PlayerPrefs.GetInt("SavePosition") == 3 && PlayerPrefs.GetInt("LoadSave") == 1)
        {
            PlayerPrefs.SetInt("LoadSave", 0);
            //PlayerPrefs.SetInt("BearPosition", 0);
            transform.position = bear.transform.position;   
        }
        if (PlayerPrefs.GetInt("SavePosition") == 4 && PlayerPrefs.GetInt("LoadSave") == 1)
        {
            PlayerPrefs.SetInt("LoadSave", 0);
            //PlayerPrefs.SetInt("WolfPosition", 0);
            transform.position = wolf.transform.position;
        }
    }
}
