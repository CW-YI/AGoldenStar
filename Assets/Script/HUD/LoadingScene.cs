using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public Text loadingText;
    public float speed = 0.1f;
    void Start()
    {
        StartCoroutine(LoadingAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingAnim()
    {
        while (true)
        {
            loadingText.text = "로딩중";
            yield return new WaitForSeconds(speed);
            loadingText.text = "로딩중 .";
            yield return new WaitForSeconds(speed);
            loadingText.text = "로딩중 ..";
            yield return new WaitForSeconds(speed);
            loadingText.text = "로딩중 ...";
            yield return new WaitForSeconds(speed);
        }
    }
}
