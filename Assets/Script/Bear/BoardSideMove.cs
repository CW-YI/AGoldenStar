using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSideMove : MonoBehaviour
{
    bool isBoardLeftMove = true;
    bool isMoving = false;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 15f * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
        else isMoving = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isMoving)
        {
            if (isBoardLeftMove)
            {
                targetPosition = new Vector3(220f, transform.position.y);
            }
            else
            {
                targetPosition = new Vector3(228f, transform.position.y);
            }
            isBoardLeftMove = !isBoardLeftMove;
        }
    }
}
