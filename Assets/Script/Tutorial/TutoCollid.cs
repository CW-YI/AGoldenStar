using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCollid : MonoBehaviour
{
    public GameObject tuto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Tutorial" && tuto != null) tuto.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tutorial" && tuto != null) tuto.SetActive(false);
    }
}
