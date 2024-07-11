using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeRestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("LoadSave", 1);
        PlayerPrefs.SetInt("PlayerStar", PlayerPrefs.GetInt("LastStar"));
        PlayerPrefs.SetInt("PlayerHP", 5);
        SceneManager.LoadScene(1);
    }

    public void GoHome()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerDeletePrefs_Restart();
        //PlayerDeletePrefs_Home();
        //PlayerPrefs.DeleteKey("LoadSave");
        PlayerPrefs.SetInt("PlayerHP", 5);
        SceneManager.LoadScene(0);
    }

    public void PlayerDeletePrefs_Restart()
    {
        
    }
    public void PlayerDeletePrefs_Home()
    {
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
