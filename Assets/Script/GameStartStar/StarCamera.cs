using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;
using static UnityEngine.GraphicsBuffer;

public class StarCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject starPiece;
    public Camera camera_;

    bool shouldZoom = true;
    public bool cameraMove = false;
    public bool Zoomout = false;
    bool lastMove = false;

    public GameObject UIStar;
    public GameObject tutorial;
    public GameObject player;
    public GameObject background;
    public GameObject Intro;
    public GameObject canvas;
    public GameObject camera__;
    public GameObject loading;
    public GameObject loadingImage;
    public GameObject loadingText;
    public PlayerMoveMent playerMM;

    public AudioSource mainBGM;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("StartIntro") || PlayerPrefs.GetInt("StartIntro") == 1)
        {
            //PlayerPrefs.SetInt("StartIntro", 1);
            transform.position = new Vector3(39.8f, 53.9f, -10f);
        }
        else if (PlayerPrefs.GetInt("StartIntro") == 0)
        {
            UIStar.SetActive(false);
            GameNONewStart();
        }
    }

    private void Update()
    {
        if (cameraMove)
        {
            if (shouldZoom)
            {
                camera_.orthographicSize = Mathf.Lerp(camera_.orthographicSize, 5f, 5f * Time.deltaTime);
                if (Mathf.Abs(camera_.orthographicSize - 5f) < 0.1f)
                {
                    camera_.orthographicSize = 5f;
                    shouldZoom = false;
                }
            }
            Vector3 dir = starPiece.transform.position - transform.position;
            Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
            transform.Translate(moveVector);
        }

        if (Zoomout)
        {
            camera_.orthographicSize = Mathf.Lerp(camera_.orthographicSize, 10f, 3f * Time.deltaTime);
            if (Mathf.Abs(camera_.orthographicSize - 10f) < 0.1f)
            {
                camera_.orthographicSize = 10f;
                Zoomout = false;
                cameraMove = false;
                PlayerPrefs.SetInt("StartIntro", 0);
                GameStart_RReday();
            }
        }

        if (lastMove)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.transform.position, 70f * Time.deltaTime);

            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            if (transform.position.x == player.transform.position.x && transform.position.y == player.transform.position.y)
            {
                lastMove = false;
                background.SetActive(false);
                camera__.GetComponent<CameraController>().enabled = true;
                canvas.SetActive(true);


                mainBGM.Play();
                playerMM.isStun = false;
                this.enabled = false;
            }
        }
    }

    void GameStart_RReday()
    {
        //GameObject obj = GameObject.Find("GoldenStarBGM");
        //if (obj != null) obj.SetActive(false);

        canvas.SetActive(true);
        loading.SetActive(false);
        loadingImage.SetActive(false);
        loadingText.SetActive(false);
        Intro.SetActive(false);
        player.SetActive(true);
        tutorial.SetActive(true);
        playerMM.isStun = true;
        canvas.SetActive(false);
        lastMove = true;
    }

    void GameNONewStart()
    {
        canvas.SetActive(true);
        loading.SetActive(true);
        loadingImage.SetActive(true);
        loadingText.SetActive(true);
        background.SetActive(false);
        Intro.SetActive(false);
        player.SetActive(true);
        tutorial.SetActive(true);
        camera__.GetComponent<CameraController>().enabled = true;
        this.enabled = false;
    }
}
