using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCamera : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public GameObject mainstar;

    private void Update()
    {
        Vector3 dir = mainstar.transform.position - transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0.0f);
        transform.Translate(moveVector);
    }
}
