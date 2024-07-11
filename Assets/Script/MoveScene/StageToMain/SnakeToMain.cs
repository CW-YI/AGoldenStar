using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeToMain : MonoBehaviour
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
        GameObject star = GameObject.Find("starPiece");
        if (star == null)
        {
            PlayerPrefs.SetInt("SnakeClear", 1);
            PlayerPrefs.SetInt("LoadSave", 1);
            PlayerPrefs.SetInt("LastStar", PlayerPrefs.GetInt("PlayerStar"));
            playtime.SavePlayTime();
            SceneManager.LoadScene(1);
        }
    }
}
