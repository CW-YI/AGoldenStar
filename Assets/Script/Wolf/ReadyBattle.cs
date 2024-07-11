using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ReadyBattle : MonoBehaviour
{
    public Transform Player;
    //public Transform Wolf;
    public Transform ReadyPosition;
    public Animator wolfAnim;
    public CameraController controller;
    public GameObject EnterWay;
    public Transform StartBattle;
    public Transform Wolf;
    public Transform CameraPosition;
    public PlayerMoveMent playerMM;
    public Camera MainCamera;
    public WolfAttack startBoss;
    public GameObject HPSlider;

    bool camerMove = false;
    bool camerWolf = false;
    float moveSpeed = 4f;
    float zoomSpeed = 3f;
    void Start()
    {
        wolfAnim.SetBool("wait", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (camerWolf)
        {
            FocusWolf();
        }

        if (camerMove)
        {
            Vector3 targetPosition = new Vector3(CameraPosition.position.x, CameraPosition.position.y, MainCamera.transform.position.z);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            // MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, 13f, zoomSpeed * Time.deltaTime);

            if (Vector3.Distance(MainCamera.transform.position, targetPosition) < 0.01f)// && Mathf.Abs(MainCamera.orthographicSize - 13f) < 0.1f)
            {
                //MainCamera.orthographicSize = 10f;
                playerMM.isStun = false;
                startBoss.BossStart();
                HPSlider.SetActive(true);
                //startBoss.StartCoroutine(startBoss.MoveAttackToWaitkZone_Right());
                gameObject.SetActive(false);
                camerMove = false;
            }
        }
    }

    void ChangeForBattle()
    {
        playerMM.isStun = true;
        controller.enabled = false;
        StartCoroutine(FocusMove());
    }
    IEnumerator MoveWolf()
    {
        wolfAnim.SetBool("wait", false);
        Wolf.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        float distanceToTarget = Mathf.Abs(Wolf.position.x - ReadyPosition.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(Wolf.position.x, ReadyPosition.position.x, 20f * Time.deltaTime);
            Wolf.position = new Vector3(newX, Wolf.position.y, Wolf.position.z);

            distanceToTarget = Mathf.Abs(Wolf.position.x - ReadyPosition.position.x);

            yield return null;
        }

        camerWolf = false;
        StartCoroutine(ZoomOut());
        Wolf.position = new Vector3(ReadyPosition.position.x, Wolf.position.y, Wolf.position.z);
        EnterWay.SetActive(true);
        Player.position = StartBattle.position;
        camerMove = true;
    }

    void FocusWolf()
    {
        Vector3 dir = Wolf.position - MainCamera.transform.position;
        Vector3 moveVector = new Vector3(dir.x * moveSpeed * Time.deltaTime, dir.y * moveSpeed * Time.deltaTime, 0.0f);
        MainCamera.transform.Translate(moveVector);
    }

    IEnumerator FocusMove()
    {
        Vector3 start = MainCamera.transform.position;
        Vector3 end = new Vector3(Wolf.position.x, Wolf.position.y, start.z);

        float t = 0f;
        while (t < 0.8f)
        {
            t += Time.deltaTime * moveSpeed * 0.2f;
            MainCamera.transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        StartCoroutine(ZoomIn());
        camerWolf = true;
    }

    IEnumerator ZoomIn()
    {
        float t = 0f;
        float currentSize = MainCamera.orthographicSize;
        while (t < 0.8f)
        {
            t += Time.deltaTime * zoomSpeed;
            MainCamera.orthographicSize = Mathf.Lerp(currentSize, 6f, t);
            yield return null;
        }

        StartCoroutine(MoveWolf());
    }

    IEnumerator ZoomOut()
    {
        float t = 0f;
        float currentSize = MainCamera.orthographicSize;
        while (t < 1f)
        {
            t += Time.deltaTime * zoomSpeed * 2;
            MainCamera.orthographicSize = Mathf.Lerp(currentSize, 10f, t);
            yield return null;
        }
        MainCamera.orthographicSize = 10f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ChangeForBattle();
        }
    }
}
