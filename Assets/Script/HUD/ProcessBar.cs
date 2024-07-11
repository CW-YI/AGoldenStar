using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProcessBar : MonoBehaviour
{
    public GameObject player;
    public GameObject fox;
    public RectTransform playerface;
    public RectTransform foxface;
    #region
    public GameObject stage1start;
    public GameObject stage1finish;
    public GameObject stage2start;
    public GameObject stage2finish;
    public GameObject stage3start;
    public GameObject stage3finish;
    public GameObject stage4start;
    public GameObject stage4finish;
    #endregion

    float distance;
    float playerPosition;
    float foxPosition;

    public float playerPercent = 0f;
    public float foxPercent = 0f;

    Vector3 OriginPosition;
    public Round round;
    void Start()
    {
        OriginPosition = playerface.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (round.roundStart)
        {
            if (round.possibleNextRound)
            {
                playerface.anchoredPosition = OriginPosition;
                foxface.anchoredPosition = OriginPosition;
            }
            else
            {
                if (round.stage == 1) Stage1Position();
                else if (round.stage == 2) Stage2Position();
                else if (round.stage == 3) Stage3Position();
                else if (round.stage == 4) Stage4Position();

                playerPercent = (playerPosition / distance) * 100;
                foxPercent = (foxPosition / distance) * 100;

                if (playerPercent <= 0f) playerPercent = 0f;
                if (foxPercent <= 0f) foxPercent = 0f;
                if (playerPercent >= 100f) playerPercent = 100f;
                if (foxPercent >= 100f) foxPercent = 100f;

                //Debug.Log("Distance : " + distance + "PlayerPosition : " + playerPosition);
                //Debug.Log(round.stage);
                //Debug.Log("player : " + playerPercent);
                //Debug.Log("fox : " + foxPercent);
                float y1 = OriginPosition.y + playerPercent;
                float y2 = OriginPosition.y + foxPercent;
                playerface.anchoredPosition = new Vector3(OriginPosition.x, y1, OriginPosition.z);
                foxface.anchoredPosition = new Vector3(OriginPosition.x, y2, OriginPosition.z);
            }
        }
    }

    void Stage1Distance()
    {
        distance = stage1finish.transform.position.x - stage1start.transform.position.x;
    }
    void Stage2Distance()
    {
        distance = stage2start.transform.position.x - stage2finish.transform.position.x;
        //distance = stage2finish.transform.position.x - stage2start.transform.position.x;
    }
    void Stage3Distance()
    {
        distance = stage3finish.transform.position.x - stage3start.transform.position.x;
    }
    void Stage4Distance()
    {
        //distance = stage4finish.transform.position.x - stage4start.transform.position.x;
        distance = stage4start.transform.position.x - stage4finish.transform.position.x;
    }

    void Stage1Position()
    {
        if (!round.possibleNextRound) Stage1Distance();
        playerPosition = player.transform.position.x - stage1start.transform.position.x;
        foxPosition = fox.transform.position.x - stage1start.transform.position.x;
    }
    void Stage2Position()
    {
        if (!round.possibleNextRound) Stage2Distance();
        playerPosition = stage2start.transform.position.x - player.transform.position.x;
        foxPosition = stage2start.transform.position.x - fox.transform.position.x;
    }
    void Stage3Position()
    {
        if (!round.possibleNextRound) Stage3Distance();
        playerPosition = player.transform.position.x - stage3start.transform.position.x;
        foxPosition = fox.transform.position.x - stage3start.transform.position.x;
    }
    void Stage4Position()
    {
        if (!round.possibleNextRound) Stage4Distance();
        playerPosition = stage4start.transform.position.x - player.transform.position.x;
        foxPosition = stage4start.transform.position.x - fox.transform.position.x;
    }
}