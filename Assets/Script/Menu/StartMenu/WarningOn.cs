using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningOn : MonoBehaviour
{
    public StartMenu menu;
    public GameObject warningNone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckKeyStart();
        //Debug.Log(menu.StartPossible);
        if (!menu.StartPossible) warningNone.SetActive(true);
        else warningNone.SetActive(false);
    }

    public void CheckKeyStart()
    {
        if (PlayerPrefs.GetString("RunKey") == "NONE" || PlayerPrefs.GetString("JumpKey") == "NONE" || PlayerPrefs.GetString("ClimbKey") == "NONE" || PlayerPrefs.GetString("CrouchKey") == "NONE" ||
            PlayerPrefs.GetString("InteractionKey") == "NONE" || PlayerPrefs.GetString("AttackKey") == "NONE") menu.StartPossible = false;
        else menu.StartPossible=true;
    }
}
