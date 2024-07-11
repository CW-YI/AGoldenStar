using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StartRoundCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject fox;
    public CameraController controller;
    public PlayerMoveMent movement;
    public GameObject player;
    public GameObject playerCamera;
    public FoxMovment foxMovement;
    public GameObject StarPiece;
    public Round round;
    public GameObject line;
    public ExitPossible exit;
    bool isFocus = false;

    float zoomSpeed = 1.5f;
    float timer = 0f;
    float duration;
    void Start()
    {
        //RoundStart();
    }
    void Update()
    {
        if (isFocus)
        {
            timer += Time.deltaTime;
            if (timer < duration)
            {
                FocusFox();
            }
            else PlayerStart();
        }
    }

    void FocusFox()
    {
        Vector3 dir = fox.transform.position - transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(moveVector);
    }

    IEnumerator FocusMove()
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(fox.transform.position.x, fox.transform.position.y, start.z);

        float t = 0f;
        while (t < 0.8f)
        {
            t += Time.deltaTime * cameraSpeed * 0.2f;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        StartCoroutine(ZoomIn());
        foxMovement.isStop = false;
        isFocus = true;   
        timer = 0f;
    }

    IEnumerator ZoomIn()
    {
        float t = 0f;
        float currentSize = Camera.main.orthographicSize;
        while (t < 0.8f)
        {
            t += Time.deltaTime * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Lerp(currentSize, 6f, t);
            yield return null;
        }
    }

    IEnumerator ZoomOut()
    {
        float t = 0f;
        float currentSize = Camera.main.orthographicSize;
        while (t < 0.8f)
        {
            t += Time.deltaTime * zoomSpeed;
            Camera.main.orthographicSize = Mathf.Lerp(currentSize, 10f, t);
            yield return null;
        }
    }
    public void RoundStart()
    {
        //movement.isStun = true;
        if (round.stage <= 4) duration = 2.5f;
        else duration = 4f;
        StartCoroutine(FocusMove());
        fox.SetActive(true);
        foxMovement.ChangeColor2();
       // player.SetActive(false);
        controller.enabled = false;
        if (round.stage == 1 || round.stage == 2) foxMovement.foxSpeed = 0.3f;
        else if (round.stage == 3) foxMovement.foxSpeed = 0.25f;
        else if (round.stage == 4) foxMovement.foxSpeed = 0.2f;
        else foxMovement.foxSpeed = 0.3f;
    }
    void PlayerStart()
    {
        //Camera.main.orthographicSize = 10f;
        StartCoroutine(ZoomOut());
        isFocus = false;
        //player.SetActive(true);
        controller.enabled = true;
        movement.isStun = false;
        if (round.stage > 4)
        {
            StarPiece.SetActive(true);
            exit.isGetStar = true;
        }
        else
        {
            line.SetActive(true);
            foxMovement.ChangeColor1();
        }

        if (round.stage == 1) foxMovement.foxSpeed = 0.13f;
        else if (round.stage == 2 || round.stage == 3) foxMovement.foxSpeed = 0.11f;
        else if (round.stage == 4) foxMovement.foxSpeed = 0.10f;
        timer = 0f;
        // 0.15 0.12 0.12 0.11
    }
}
