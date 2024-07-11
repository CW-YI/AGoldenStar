using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        var render = GetComponent<Renderer>();
        render.sortingLayerID = SortingLayer.NameToID("Ground");
        render.sortingOrder = 2;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = startPos + new Vector3(0.0f, Mathf.Sin(Time.time * 5f) * 0.3f, 0.0f);
        transform.position = newPos;
    }
}
