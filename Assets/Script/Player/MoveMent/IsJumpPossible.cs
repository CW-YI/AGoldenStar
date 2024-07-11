using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsJumpPossible : MonoBehaviour
{
    public PlayerMoveMent moveMent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground") moveMent.isJumpPossible = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground") moveMent.isJumpPossible = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground") moveMent.isJumpPossible = true;
    }
}
