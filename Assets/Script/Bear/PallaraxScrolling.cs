using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaraxScrolling : MonoBehaviour
{
    public Transform ground_leftPoint, ground_rightPoint;
    public Transform player;
    float ground_sideSpace = 0f;
    public float parallaxSpeed = 0.5f;

    private void Start()
    {
        ground_sideSpace = ground_rightPoint.position.x - ground_leftPoint.position.x; // ¸Ê Å©±â
        
    }

    private void LateUpdate()
    {
        SetPosition();
    }

    void SetPosition()
    {
        float player_ground_Space = player.position.x - ground_leftPoint.position.x;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = 1 - ((player_ground_Space / ground_sideSpace) * parallaxSpeed + 0.2f);
        if (pos.x < 0) pos.x = 0;
        if (pos.x > 1) pos.x = 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
