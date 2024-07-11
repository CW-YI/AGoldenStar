using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCave : MonoBehaviour
{
    public GameObject cave;
    BoxCollider2D col;
    public bool isOn = false;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cave.activeSelf && !isOn) TurnOnTirgger();
    }

    void TurnOnTirgger()
    {
        col.isTrigger = true;
        isOn = true;
    }
}
