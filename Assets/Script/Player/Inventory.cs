using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region starobj
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    public GameObject star6;
    #endregion

    public int starNum = 0;
    public PauseButton pauseButton;
    void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerStar")) starNum = PlayerPrefs.GetInt("PlayerStar");
        else { starNum = 0; PlayerPrefs.SetInt("PlayerStar", 0); }
    }

    // Update is called once per frame
    void Update()
    {
        if(!pauseButton.isPause) starUI();
    }

    public void PlusStarNum()
    {
        starNum++;
        PlayerPrefs.SetInt("PlayerStar", starNum);
    }
     void starUI()
    {
        if (starNum == 0) Star0();
        if (starNum == 1) Star1();
        if (starNum == 2) Star2();
        if (starNum == 3) Star3();
        if (starNum == 4) Star4();
        if (starNum == 5) Star5();
        if (starNum == 6) Star6();
    }

    void Star0()
    {
        star1.SetActive(false); star2.SetActive(false); star3.SetActive(false); 
        star4.SetActive(false); star5.SetActive(false); star6.SetActive(false);
    }
    void Star1()
    {
        star1.SetActive(true); star2.SetActive(false); star3.SetActive(false);
        star4.SetActive(false); star5.SetActive(false); star6.SetActive(false);
    }

    void Star2()
    {
        star1.SetActive(false); star2.SetActive(true); star3.SetActive(false);
        star4.SetActive(false); star5.SetActive(false); star6.SetActive(false);
    }
    void Star3()
    {
        star1.SetActive(false); star2.SetActive(false); star3.SetActive(true);
        star4.SetActive(false); star5.SetActive(false); star6.SetActive(false);
    }
    void Star4()
    {
        star1.SetActive(false); star2.SetActive(false); star3.SetActive(false);
        star4.SetActive(true); star5.SetActive(false); star6.SetActive(false);
    }
    void Star5()
    {
        star1.SetActive(false); star2.SetActive(false); star3.SetActive(false);
        star4.SetActive(false); star5.SetActive(true); star6.SetActive(false);
    }
    void Star6()
    {
        star1.SetActive(false); star2.SetActive(false); star3.SetActive(false);
        star4.SetActive(false); star5.SetActive(false); star6.SetActive(true);
    }
}
