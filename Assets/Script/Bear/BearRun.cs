using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearRun : MonoBehaviour
{
    public float speed = 15f;
    public GameObject Player;

    private void Start()
    {
        transform.position = new Vector3(Player.transform.position.x - 30f, transform.position.y, transform.position.z);
    }
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
