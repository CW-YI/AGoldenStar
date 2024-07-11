using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public bool isPause = false;
    #region UI
    public GameObject pausePanel;
    public GameObject pasue_resume;
    public GameObject pause_title;
    public GameObject pause_mainmenu;
    public GameObject pause_exit;

    public GameObject pause_exit_warning;
    public GameObject pause_exit_yes;
    public GameObject pause_exit_no;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public GameObject StarPiece1;
    public GameObject StarPiece2; 
    public GameObject StarPiece3;   
    public GameObject StarPiece4;   
    public GameObject StarPiece5;   
    public GameObject StarPiece6;
    public GameObject UI;
    public GameObject FoxUI;
    public Round Foxround;
    #endregion

    public PlayTime playtime;
    //public Canvas pasuePanel;
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        PausePanelOn();
        UIFalse();   
        isPause = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        UITrue();
        pausePanel.SetActive(false);
        PausePanelOff();
        isPause = false;
        Time.timeScale = 1f;
    }

    public void GoMainMenu()
    {
        pausePanel.SetActive(false);
        PausePanelOff();
        isPause = false;
        //PlayerDeletePrefs();
        Time.timeScale = 1f;
        playtime.SavePlayTime();
        if(PlayerPrefs.GetInt("TutorialClear") == 0)
        {

            PlayerPrefs.DeleteKey("TutorialClear");
            PlayerPrefs.DeleteKey("SavePosition");
            PlayerPrefs.DeleteKey("LoadSave");
            PlayerPrefs.SetInt("StartIntro", 1);
        }
        SceneManager.LoadScene(0);
    }

    public void ExitDungeon()
    {
        PausePanelOff();
        pause_exit_warning.SetActive(true);
        pause_exit_yes.SetActive(true);
        pause_exit_no.SetActive(true);
    }

    public void YesExitDungeon()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("PlayerStar", PlayerPrefs.GetInt("LastStar"));
        PlayerPrefs.SetInt("LoadSave", 1);
        playtime.SavePlayTime();
        SceneManager.LoadScene(1);
    }

    public void NoExitDungeon()
    {
        if (pause_exit_warning != null) pause_exit_warning.SetActive(false);
        if (pause_exit_yes != null) pause_exit_yes.SetActive(false);
        if (pause_exit_no != null) pause_exit_no.SetActive(false);
        PausePanelOn();
    }

    void PausePanelOn()
    {
        pasue_resume.SetActive(true);
        pause_mainmenu.SetActive(true);
        pause_title.SetActive(true);
        if (pause_exit != null) pause_exit.SetActive(true);
    }

    void PausePanelOff()
    {
        pasue_resume.SetActive(false);
        pause_mainmenu.SetActive(false);
        pause_title.SetActive(false);
        if (pause_exit != null) pause_exit.SetActive(false);
    }
    void UIFalse()
    {
        UI.SetActive(false);
        life1.SetActive(false); life2.SetActive(false); life3.SetActive(false);
        life4.SetActive(false); life5.SetActive(false);
        StarPiece1.SetActive(false); StarPiece2.SetActive(false);
        StarPiece3.SetActive(false); StarPiece4.SetActive(false);
        StarPiece5.SetActive(false); StarPiece6.SetActive(false);
        if (FoxUI != null && Foxround != null && Foxround.roundStart) FoxUI.SetActive(false);
    }

    void UITrue()
    {
        UI.SetActive(true);
        life1.SetActive(true); life2.SetActive(true); life3.SetActive(true);
        life4.SetActive(true); life5.SetActive(true);
        StarPiece1.SetActive(true); StarPiece2.SetActive(true);
        StarPiece3.SetActive(true); StarPiece4.SetActive(true);
        StarPiece5.SetActive(true); StarPiece6.SetActive(true);
        if (FoxUI != null && Foxround != null && Foxround.roundStart) FoxUI.SetActive(true);
    }

    public void PlayerDeletePrefs()
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
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isPause)
        {
            PauseGame();
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && isPause)
        {
            if (pause_exit_warning != null) pause_exit_warning.SetActive(false);
            if (pause_exit_yes != null) pause_exit_yes.SetActive(false);
            if (pause_exit_no != null) pause_exit_no.SetActive(false);
            ResumeGame();
        }
    }
}
