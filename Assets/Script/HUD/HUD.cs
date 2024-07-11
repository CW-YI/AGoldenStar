using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Image image;
    public Sprite HP100;
    public Sprite HP80;
    public Sprite HP60;
    public Sprite HP40;
    public Sprite HP20;
    public Sprite HP0;

    public PlayerStateMachine playerState;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
    }

    public void ChangeHPImage()
    {
        if (playerState.playerLife == 5) image.sprite = HP100;
        else if (playerState.playerLife == 4) image.sprite = HP80;
        else if (playerState.playerLife== 3) image.sprite = HP60;
        else if (playerState.playerLife == 2) image.sprite = HP40;
        else if (playerState.playerLife == 1) image.sprite = HP20;
        else if (playerState.playerLife == 0) image.sprite = HP0;
    }
}
