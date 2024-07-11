using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.GraphicsBuffer;

public class ToEndingScene : MonoBehaviour
{
    bool start = true;

    public PlayerMoveMent playerMM;
    public GameObject mainstar;
    public Transform targetPosition1; 
    public CameraController controller;
    public EndingCamera endingCamera;

    public GameObject UI;
    public GameObject UIstar;
    public Image Uistar; 
    public RectTransform uiStar;
    public Transform targetPosition2;
    public Camera uiCamera;
    
    public GameObject mainstarBoom;
    public SpriteRenderer black;
    float speed = 6f;

    public PlayTime playtime;
    public AudioSource mainBGM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartEnding()
    {
        StartCoroutine(BGMFadeOut());
        start = false;
        playerMM.isStun = true;
        controller.enabled = false;
        endingCamera.enabled = true;
        UI.SetActive(false);
        StartCoroutine(MoveToPosition());
    }

    IEnumerator BGMFadeOut()
    {
        float startVolume = mainBGM.volume;

        while (mainBGM.volume > 0)
        {
            mainBGM.volume -= startVolume * Time.deltaTime / 2f;
            yield return null;
        }

        mainBGM.Stop();

        BGMContinue bgmcontinue = FindObjectOfType<BGMContinue>();
        if (bgmcontinue != null) { bgmcontinue.StartCoroutine(bgmcontinue.BGMFadeIn()); }
    }

    IEnumerator MoveToPosition()
    {
        while (Vector3.Distance(mainstar.transform.position, targetPosition1.position) > 0.01f)
        {
            mainstar.transform.position = Vector3.MoveTowards(mainstar.transform.position, targetPosition1.position, speed * Time.deltaTime);
            yield return null;
        }

        mainstar.transform.position = targetPosition1.position;
        endingCamera.enabled = false;
        Vector3 worldPoint = uiCamera.ScreenToWorldPoint(uiStar.position);
        targetPosition2.position = worldPoint;

        StartCoroutine(MoveToPosition_2());
    }


    IEnumerator MoveToPosition_2()
    {
        while (Vector3.Distance(mainstar.transform.position, targetPosition2.position) > 0.01f)
        {
            mainstar.transform.position = Vector3.MoveTowards(mainstar.transform.position, targetPosition2.position, speed * Time.deltaTime);
            yield return null;
        }

        mainstar.transform.position = targetPosition2.position;
        
        mainstarBoom.transform.position = new Vector3(targetPosition2.position.x, targetPosition2.position.y, 0f);
        
        mainstar.SetActive(false);
        mainstarBoom.SetActive(true);
        StartCoroutine(StarFadeIn());
    }

    IEnumerator StarFadeIn()
    {
        yield return new WaitForSeconds(1f);
        UIstar.SetActive(true);

        Color color = Uistar.color;
        color.a = 0;
        Uistar.color = color;

        while (color.a < 1f)
        {
            color.a += 1f * Time.deltaTime;
            Uistar.color = color;
            yield return null;
        }

        color.a = 1;
        Uistar.color = color;
        StartCoroutine(ParticelFadeIn());
    }

    IEnumerator ParticelFadeIn()
    {
        Color color = black.color;
        color.a = 0;
        black.color = color;

        while (color.a < 1f)
        {
            color.a += 1f * Time.deltaTime;
            black.color = color;
            yield return null;
        }

        color.a = 1;
        black.color = color;
        yield return new WaitForSeconds(0.3f);
        playtime.SavePlayTime();
        SceneManager.LoadScene(3);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (start) StartEnding();
        }
    }
}
