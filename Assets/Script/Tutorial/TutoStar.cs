using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoStar : MonoBehaviour
{
    public GameObject tutoPlayer;
    void Awake()
    {
        if (!PlayerPrefs.HasKey("TutorialClear"))
        {
            PlayerPrefs.SetInt("TutorialClear", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("TutorialClear") == 1)
        {
            tutoPlayer.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
