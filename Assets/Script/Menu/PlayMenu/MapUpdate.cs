using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpdate : MonoBehaviour
{
    public GameObject fox;
    public GameObject snake;
    public GameObject bear;
    public GameObject wolf;
    bool is_fox = false;
    bool is_snake = false;
    bool is_bear = false;
    bool is_wolf = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("FoxClear") == 1 && !is_fox) { fox.SetActive(true); is_fox = true; }
        if (PlayerPrefs.GetInt("SnakeClear") == 1 && !is_snake) { snake.SetActive(true); is_snake = true; }
        if (PlayerPrefs.GetInt("BearClear") == 1 && !is_bear) { bear.SetActive(true); is_bear = true; }
        if (PlayerPrefs.GetInt("WolfClear") == 1 && !is_wolf) { wolf.SetActive(true); is_wolf = true; }
    }
}
