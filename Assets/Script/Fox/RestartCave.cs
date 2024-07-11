using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCave : MonoBehaviour
{
    #region stage1
    public GameObject cave1;
    public GameObject cave1_1;
    public GameObject cave1_2;
    public GameObject cave1_3;
    public BoxCollider2D clear1;
    public ClearCave clearcave1;
    #endregion

    #region stage2
    public GameObject cave2;
    public GameObject cave2_1;
    public GameObject cave2_2;
    public GameObject cave2_3;
    public BoxCollider2D clear2;
    public ClearCave clearcave2;
    #endregion

    #region stage3
    public GameObject cave3;
    public GameObject cave3_1;
    public GameObject cave3_2;
    public GameObject cave3_3;
    public BoxCollider2D clear3;
    public ClearCave clearcave3;
    #endregion

    #region stage4
    public GameObject cave4;
    public GameObject cave4_1;
    public GameObject cave4_2;
    public GameObject cave4_3;
    //public BoxCollider2D clear4;
    #endregion
    
    public void RestartStage1()
    {
        cave1.SetActive(true);
        cave1_1.SetActive(true);
        cave1_2.SetActive(false);
        cave1_3.SetActive(false);
        clear1.isTrigger = false;
        clearcave1.isOn = false;
    }

    public void RestartStage2()
    {
        cave2.SetActive(true);
        cave2_1.SetActive(true);
        cave2_2.SetActive(false);
        cave2_3.SetActive(false);
        clear2.isTrigger = false;
        clearcave2.isOn = false;
    }

    public void RestartStage3()
    {
        cave3.SetActive(true);
        cave3_1.SetActive(true);
        cave3_2.SetActive(false);
        cave3_3.SetActive(false);
        clear3.isTrigger = false;
        clearcave3.isOn = false;
    }

    public void RestartStage4()
    {
        cave4.SetActive(true);
        cave4_1.SetActive(true);
        cave4_2.SetActive(false);
        cave4_3.SetActive(false);
    }
}
