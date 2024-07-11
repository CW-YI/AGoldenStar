using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTime : MonoBehaviour
{
    float playtime = 0f;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("PlayTime")) PlayerPrefs.SetFloat("PlayTime", 0);
        else playtime = PlayerPrefs.GetFloat("PlayTime");
    }

    // Update is called once per frame
    void Update()
    {
        playtime += Time.deltaTime;
    }

    public void SavePlayTime()
    {
        PlayerPrefs.SetFloat("PlayTime", playtime);
        Debug.Log("플레이타임 : " + PlayerPrefs.GetFloat("PlayTime"));
    }
}
