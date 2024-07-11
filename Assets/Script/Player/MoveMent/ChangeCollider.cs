using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    public PlayerMoveMent moveMent;
    public GameObject CrouchCollider;
    CapsuleCollider2D capsuleCollider;
    public GameObject headCollier;
    public PlayerRoll roll;
    public GameObject JumpCollider;
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveMent.isCrouch || roll.isRoll)
        {
            CrouchCollider.SetActive(true);
            capsuleCollider.enabled = false;
            headCollier.SetActive(false);
        }
        else
        {
            capsuleCollider.enabled = true;
            CrouchCollider.SetActive(false);
            headCollier.SetActive(true);
        }

        if (moveMent.isJump)
        {
            JumpCollider.SetActive(true);
            capsuleCollider.enabled = false;
        }
        else
        {
            capsuleCollider.enabled = true;
            JumpCollider.SetActive(false);
        }
    }
}
