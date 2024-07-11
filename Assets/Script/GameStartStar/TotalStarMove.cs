using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TotalStarMove : MonoBehaviour
{
    public Image Star;
    public Transform target;
    public GameObject totalStar;
    public GameObject totalStarBoom;

    public GameObject starPiece1;
    public GameObject starPiece2;
    public GameObject starPiece3;
    public GameObject starPiece4;
    public GameObject starPiece5;
    public GameObject starPiece6;

    public GameObject starPieceBoom1;
    public GameObject starPieceBoom2;
    public GameObject starPieceBoom3;
    public GameObject starPieceBoom4;
    public GameObject starPieceBoom5;
    public GameObject starPieceBoom6;

    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;    
    public Transform target5;
    public Transform target6;
    public float speed = 5f;

    bool star1 = false;
    bool star2 = false;
    bool star3 = false;
    bool star4 = false;
    bool star5 = false;
    bool star6 = false;

    bool step_1 = false;
    bool step_2 = false;

    public StarCamera StarCamera;
    public GameObject Piece_On;

    public RectTransform uiStar;
    public Camera uiCamera;
    bool isFirst = false;
    private void Start()
    {
        StartCoroutine(StarFadeIn());
        //start_star();
    }
    IEnumerator StarFadeIn()
    {
        Color color = Star.color;
        color.a = 1;
        while (color.a > 0)
        {
            color.a -= 0.5f * Time.deltaTime;
            Star.color = color;
            yield return null;
        }

        color.a = 0;
        Star.color = color;

        Vector3 worldPoint = uiCamera.ScreenToWorldPoint(uiStar.position);
        totalStar.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        totalStar.SetActive(true);
        Invoke(nameof(start_star), 2f);
        //start_star();
    }
    void start_star()
    {
        step_1 = true;
    }
    private void Update()
    {
        if (step_1)
        {
            Vector2 newPosition = Vector2.MoveTowards(totalStar.transform.position, target.position, speed * Time.deltaTime);

            totalStar.transform.position = newPosition;

            if (totalStar.transform.position == target.position)
            {
                totalStarBoom.transform.position = totalStar.transform.position;
                totalStar.SetActive(false);
                totalStarBoom.SetActive(true);
                step_1 = false;
                
                Invoke(nameof(starPieceStart), 0.5f);
            }
        }

        if (step_2)
        {
            MoveStarPiece();
            
            if (star1 && star2 && star3 && star4 && star5 && star6)
            {
                step_2 = false;
            }
        }
    }

    void starPieceStart()
    {
        step_2 = true;
        starPiece1.transform.position = totalStar.transform.position;
        starPiece2.transform.position = totalStar.transform.position;
        starPiece3.transform.position = totalStar.transform.position;
        starPiece4.transform.position = totalStar.transform.position;
        starPiece5.transform.position = totalStar.transform.position;
        starPiece6.transform.position = totalStar.transform.position;
        starPiece1.SetActive(true); starPiece2.SetActive(true); starPiece3.SetActive(true);
        starPiece4.SetActive(true); starPiece5.SetActive(true); starPiece6.SetActive(true);
        StarCamera.cameraMove = true;
        speed = 12f;
    }

    void GameStart_Ready()
    {
        BGMContinue bgmcontinue = FindObjectOfType<BGMContinue>();
        if (bgmcontinue != null) { bgmcontinue.StartCoroutine(bgmcontinue.BGMFadeOut()); }
        StarCamera.Zoomout = true;
    }

    void pieceOn()
    {
        Piece_On.SetActive(true);
    }
    void MoveStarPiece()
    {
        starPiece1.transform.position = Vector2.MoveTowards(starPiece1.transform.position, target1.position, speed * Time.deltaTime);
        starPiece2.transform.position = Vector2.MoveTowards(starPiece2.transform.position, target2.position, speed * Time.deltaTime);
        starPiece3.transform.position = Vector2.MoveTowards(starPiece3.transform.position, target3.position, speed * Time.deltaTime);
        starPiece4.transform.position = Vector2.MoveTowards(starPiece4.transform.position, target4.position, speed * Time.deltaTime);
        starPiece5.transform.position = Vector2.MoveTowards(starPiece5.transform.position, target5.position, speed * Time.deltaTime);
        starPiece6.transform.position = Vector2.MoveTowards(starPiece6.transform.position, target6.position, speed * Time.deltaTime);

        if (starPiece1.transform.position == target1.position)
        {
            starPieceBoom1.transform.position = starPiece1.transform.position;
            starPiece1.SetActive(false);
            starPieceBoom1.SetActive(true);
            star1 = false;
        }
        if (starPiece2.transform.position == target2.position)
        {
            starPieceBoom2.transform.position = starPiece2.transform.position;
            starPiece2.SetActive(false);
            starPieceBoom2.SetActive(true);
            star2 = false;
        }
        if (starPiece3.transform.position == target3.position)
        {
            starPieceBoom3.transform.position = starPiece3.transform.position;
            starPiece3.SetActive(false);
            starPieceBoom3.SetActive(true);
            star3 = false;
            if (!isFirst)
            {
                isFirst = true;
                Invoke(nameof(pieceOn), 0.6f);
                Invoke(nameof(GameStart_Ready), 1.5f);
            }
        }
            if (starPiece4.transform.position == target4.position)
        {
            starPieceBoom4.transform.position = starPiece4.transform.position;
            starPiece4.SetActive(false);
            starPieceBoom4.SetActive(true);
            star4 = false;
        }
        if (starPiece5.transform.position == target5.position)
        {
            starPieceBoom5.transform.position = starPiece5.transform.position;
            starPiece5.SetActive(false);
            starPieceBoom5.SetActive(true);
            star5 = false;
        }
        if (starPiece6.transform.position == target6.position)
        {
            starPieceBoom6.transform.position = starPiece6.transform.position;
            starPiece6.SetActive(false);
            starPieceBoom6.SetActive(true);
            star6 = false;
        }
    }
}
