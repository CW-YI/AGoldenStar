using UnityEngine;

public class Round : MonoBehaviour
{
    public int stage = 1;
    public bool possibleNextRound = true;
    public bool roundStart = false;
    #region fox
    public GameObject Fox;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Ending;
    public FoxMovment FoxMovment;
    #endregion

    #region player
    public PlayerMoveMent movement;
    public GameObject restart1;
    public GameObject restart2;
    public GameObject restart3;
    public GameObject restart4;
    #endregion

    public RestartCave restartcave;
    public StartRoundCamera StartCamera;
    public bool stageClear = false;
    public GameObject line;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(stage);
    }

    public void RoundStart()
    {
        roundStart = true;
        stageClear = false;
        movement.isStun = true;

        Fox.SetActive(true);

        if (stage == 1)
        {
            Fox.transform.position = Stage1.transform.position;
            restartcave.RestartStage1();
        }
        else if (stage == 2)
        {
            Fox.transform.position = Stage2.transform.position;
            restartcave.RestartStage2();
        }
        else if (stage == 3)
        {
            Fox.transform.position = Stage3.transform.position;
            restartcave.RestartStage3();
        }
        else if (stage == 4)
        {
            Fox.transform.position = Stage4.transform.position;
            restartcave.RestartStage4();
        }
        else if (stage == 5)
        {
            Fox.transform.position = Ending.transform.position;
        }

        StartCamera.RoundStart();
        FoxMovment.isStop = false;
    }

    public void RoundRestart()
    {
        line.SetActive(false);
        roundStart = false;
        if (stage == 1) transform.position = restart1.transform.position;
        else if (stage == 2) transform.position = restart2.transform.position;
        else if (stage == 3) transform.position = restart3.transform.position;
        else if (stage == 4) transform.position = restart4.transform.position;
        possibleNextRound = true;
        //RoundStart();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "round1start" && possibleNextRound)
        {
            stage = 1; possibleNextRound = false;
            RoundStart();
        }

        if (collision.gameObject.name == "round2start" && possibleNextRound)
        {
            stage = 2; possibleNextRound = false;
            RoundStart();
        }
        if (collision.gameObject.name == "round3start" && possibleNextRound)
        {
            stage = 3; possibleNextRound = false;
            RoundStart();
        }
        if (collision.gameObject.name == "round4start" && possibleNextRound)
        {
            stage = 4; possibleNextRound = false;
            RoundStart();
        }

        if (collision.gameObject.name == "round1clear" || collision.gameObject.name == "round2clear" || collision.gameObject.name == "round3clear" || collision.gameObject.name == "round4clear")
        {
            possibleNextRound = true;
        }
    }
}
