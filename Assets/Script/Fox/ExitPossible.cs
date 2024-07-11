using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPossible : MonoBehaviour
{
    public bool isGetStar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetStar)
        {
            GameObject star = GameObject.Find("starPiece");
            if (star == null)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
