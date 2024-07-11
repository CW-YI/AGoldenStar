using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCamera : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 저장할 변수

    void Update()
    {
        if (player != null)
        {
            // 플레이어의 위치를 따라가도록 오브젝트 위치 설정
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
