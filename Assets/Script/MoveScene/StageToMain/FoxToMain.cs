using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxToMain : MonoBehaviour
{
    public PlayTime playtime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("LoadScene", 1);
        }
    }
    void LoadScene()
    {
        PlayerPrefs.SetInt("FoxClear", 1);
        PlayerPrefs.SetInt("LoadSave", 1);
        PlayerPrefs.SetInt("LastStar", PlayerPrefs.GetInt("PlayerStar"));
        playtime.SavePlayTime();
        SceneManager.LoadScene(1);
    }
}