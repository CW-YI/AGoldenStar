using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightofStar : MonoBehaviour
{
    Light bright;
    public float brightNum = 3f;
    public float dimAmount = 0.38f;
    public bool isEnding = false;

    public Transform Player;
    public Interaction interaction;
    public Transform endingRestart;
    public GameObject fadein;
    public GameObject fadeout;
    void Awake()
    {
        bright = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("PlayerStar") && !isEnding) bright.range = PlayerPrefs.GetInt("PlayerStar") * brightNum;
    }

    public IEnumerator DimLight()
    {
        while (bright.range > 0)
        {
            bright.range -= dimAmount;
            Debug.Log(bright.range);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Á¾·á : " + interaction.endingStar);
        if (!interaction.endingStar)
        {
            fadeout.SetActive(true);
        }
    }
    public void EndingRestart()
    {
        Player.position = new Vector3(endingRestart.position.x, endingRestart.position.y, 0);
        bright.range = 15f;
    }


}
