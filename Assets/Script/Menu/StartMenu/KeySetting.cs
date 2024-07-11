using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeySetting : MonoBehaviour
{
    string PrefKey = string.Empty;
    Dictionary<KeyCode, string> keyDictionary;

    public enum InfoType { Run, Jump, Crouch, Climb, Interaction ,Attack, Roll}
    public InfoType type;
    Text text;

    void Awake()
    {
       text = GetComponent<Text>();
    }
    
    private void Start()
    {
        keyDictionary = new Dictionary<KeyCode, string>
        {
            { KeyCode.Tab, "tab" }, { KeyCode.Backspace, "backspace"},
            { KeyCode.CapsLock, "caps lock" }, //{ KeyCode.Return, "return"},
            { KeyCode.LeftShift, "left shift" }, { KeyCode.RightShift, "right shift" },
            { KeyCode.LeftControl, "left ctrl" }, { KeyCode.RightControl, "right ctrl" },
            { KeyCode.LeftAlt, "left alt" }, { KeyCode.RightAlt, "right alt" },
            { KeyCode.Space, "space" }
        };

    }

    void LateUpdate()
    {
        if (text != null)
        {
            switch (type)
            {
                case InfoType.Run:
                    text.text = string.Format(PlayerPrefs.GetString("RunKey"));
                    break;
                case InfoType.Jump:
                    text.text = string.Format(PlayerPrefs.GetString("JumpKey"));
                    break;
                case InfoType.Crouch:
                    text.text = string.Format(PlayerPrefs.GetString("CrouchKey"));
                    break;
                case InfoType.Climb:
                    text.text = string.Format(PlayerPrefs.GetString("ClimbKey"));
                    break;
                case InfoType.Interaction:
                    text.text = string.Format(PlayerPrefs.GetString("InteractionKey"));
                    break;
                case InfoType.Attack:
                    text.text = string.Format(PlayerPrefs.GetString("AttackKey"));
                    break;
                //case InfoType.Roll:
                //    text.text = string.Format(PlayerPrefs.GetString("RollKey"));
                //    break;
            }
        }
    }
    IEnumerator WaitForKeyInput()
    {
        string newKeyName = "";
        PlayerPrefs.SetString(PrefKey, "enter key");

        //HashSet<KeyCode> alreadyPressedKeys = new HashSet<KeyCode>();
        while (true)
        {
            Debug.Log("키를 입력하세요 : ");
            yield return new WaitUntil(() => Input.anyKey || Input.GetMouseButton(0) || Input.GetMouseButton(1));

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1)) newKeyName = "NONE";
            else
            {
                KeyCode pressedKey = GetPressedKey();

                if (keyDictionary.ContainsKey(pressedKey))
                {
                    newKeyName = keyDictionary[pressedKey];
                }
                else if (IsSpecialKey(pressedKey))
                {
                    newKeyName = "NONE";
                }
                else
                {
                    newKeyName = Input.inputString;
                }
            }

            newKeyName = newKeyName.ToLower();
            CheckKey(newKeyName);
            PlayerPrefs.SetString(PrefKey, newKeyName);

            Debug.Log("입력 키 : " + newKeyName);
            checkCoroutine = null;
            yield break;
        }
    }

    KeyCode GetPressedKey()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                return keyCode;
            }
        }
        return KeyCode.None;
    }

    void CheckKey(string keyName)
    {
        if (PlayerPrefs.GetString("RunKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("RunKey", "NONE");
        }
        if (PlayerPrefs.GetString("JumpKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("JumpKey", "NONE");
        }
        if (PlayerPrefs.GetString("ClimbKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("ClimbKey", "NONE");
        }
        if (PlayerPrefs.GetString("CrouchKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("CrouchKey", "NONE");
        }
        if (PlayerPrefs.GetString("InteractionKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("InteractionKey", "NONE");
        }
        if (PlayerPrefs.GetString("AttackKey") == keyName && keyName != "enter key" && keyName != "NONE")
        {
            PlayerPrefs.SetString("AttackKey", "NONE");
        }
        //if (PlayerPrefs.GetString("RollKey") == keyName && keyName != "enter key" && keyName != "NONE")
        //{
        //    PlayerPrefs.SetString("RollKey", "NONE");
        //}
    }

    Coroutine checkCoroutine = null;
    public void UpdateRunKey()
    {
        PrefKey = "RunKey"; 
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    public void UpdateJumpKey()
    {
        PrefKey = "JumpKey";
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    public void UpdateClimbKey()
    {
        PrefKey = "ClimbKey"; 
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    public void UpdateCrouchKey()
    {
        PrefKey = "CrouchKey";
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    public void UpdateInteractionKey()
    {
        PrefKey = "InteractionKey";
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    public void UpdateAttackKey()
    {
        PrefKey = "AttackKey";
        if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }

    public void UpdateRollKey()
    {
        //PrefKey = "RollKey";
        //if (checkCoroutine == null) checkCoroutine = StartCoroutine(WaitForKeyInput());
    }
    bool IsSpecialKey(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Escape:
            case KeyCode.F1:
            case KeyCode.F2:
            case KeyCode.F3:
            case KeyCode.F4:
            case KeyCode.F5:
            case KeyCode.F6:
            case KeyCode.F7:
            case KeyCode.F8:
            case KeyCode.F9:
            case KeyCode.F10:
            case KeyCode.F11:
            case KeyCode.F12:
            case KeyCode.Delete:
            case KeyCode.Insert:
            case KeyCode.Home:
            case KeyCode.End:
            case KeyCode.PageUp:
            case KeyCode.PageDown:
            case KeyCode.Print:
            case KeyCode.ScrollLock:
            case KeyCode.Pause:
            case KeyCode.DownArrow:
            case KeyCode.LeftArrow:
            case KeyCode.RightArrow:
            case KeyCode.UpArrow:
            case KeyCode.Return:
                return true;
            default:
                return false;
        }
    }
   
}
