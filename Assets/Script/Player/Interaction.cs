using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    #region interaction
    bool InteractionPossible = false;
    public bool isInteraction = false;
    bool AcquirePossible = false;
    public bool isAcqure = false;
    #endregion

    public Inventory inventory;
    bool isEnding = false;
    public BrightTimer brightTimer;
    public GameObject tutoPlayer;
    public bool endingStar = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialClear") == 1)
        {
            if (tutoPlayer != null) tutoPlayer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionPossible) { isInteraction = Input.GetKeyDown(PlayerPrefs.GetString("InteractionKey")); }//Debug.Log("interaction key"); }
        if (isInteraction)
        {
            //
        }
        if (AcquirePossible) isAcqure = Input.GetKeyDown(PlayerPrefs.GetString("InteractionKey"));
        if (isAcqure)
        {
            if (isEnding) EndingStar();
            else AquireStar();
        }
    }

    void EnterDungeon()
    {
        //
    }
    void AquireStar()
    {
        GameObject star = GameObject.Find("starPiece");
        if (star == null) Debug.Log("starPiece를 찾을 수 없음");
        else
        {
            inventory.PlusStarNum();
            star.SetActive(false);
            AcquirePossible = isAcqure = false;
            //Scene number 4 : fox, 5 : snake, 6 : bear, 7 : wolf
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if(tutoPlayer != null) tutoPlayer.SetActive(false);
                PlayerPrefs.SetInt("LastStar", PlayerPrefs.GetInt("PlayerStar"));
                PlayerPrefs.SetInt("TutorialClear", 1);
            }
            //else if (SceneManager.GetActiveScene().buildIndex == 4) PlayerPrefs.SetInt("FoxClear", 1);
            //else if (SceneManager.GetActiveScene().buildIndex == 5) PlayerPrefs.SetInt("SnakeClear", 1);
            //else if (SceneManager.GetActiveScene().buildIndex == 6) PlayerPrefs.SetInt("BearClear", 1);
            //else if (SceneManager.GetActiveScene().buildIndex == 7) PlayerPrefs.SetInt("WolfClear", 1);

        }
    }

    void EndingStar()
    {
        GameObject star = GameObject.Find("EndingstarPiece");
        if (star == null) Debug.Log("EndingstarPiece를 찾을 수 없음");
        else
        {
            if (!endingStar) endingStar = true;
            inventory.PlusStarNum();
            star.SetActive(false);
            AcquirePossible = isAcqure = false;
            if (brightTimer != null) brightTimer.LightON();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AcquireStar")
        {
            //InteractionPossible = true;
            AcquirePossible = true;
        }
        if (collision.gameObject.tag == "EndingStar")
        {
            AcquirePossible = true;  isEnding = true;
        }
        if (collision.gameObject.tag == "Interaction")
        {
            InteractionPossible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AcquireStar")
        {
            AcquirePossible = false;
        }
        if (collision.gameObject.tag == "EndingStar")
        {
            AcquirePossible = false;
        }
        if (collision.gameObject.tag == "Interaction")
        {
            InteractionPossible = false;
        }
    }
}
