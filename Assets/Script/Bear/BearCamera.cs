using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCamera : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� ������ ����

    void Update()
    {
        if (player != null)
        {
            // �÷��̾��� ��ġ�� ���󰡵��� ������Ʈ ��ġ ����
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
