using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoveScene : MonoBehaviour
{
    public int moveScene = 4;
    public MainToFox fox;
    public MainToBear bear;
    public MainToSnake snake;
    public MainToWolf wolf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonYes()
    {
        if (moveScene == 4) fox.LoadScene();
        else if (moveScene == 5) bear.LoadScene();
        else if (moveScene == 6) snake.LoadScene();
        else if (moveScene == 7) wolf.LoadScene();
    }

    public void ButtonNo()
    {
        if (moveScene == 4) fox.ExitExplain();
        else if (moveScene == 5) bear.ExitExplain();
        else if (moveScene == 6) snake.ExitExplain();
        else if (moveScene == 7) wolf.ExitExplain();
    }
}
