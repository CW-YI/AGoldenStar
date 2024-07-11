using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    Coroutine isAnimation;
    bool isAttackKeyDown;
    bool isAttackPossible = true;
    private bool isAttack = true;
    public bool attack = false;
    [SerializeField] private float attackDelay = 1f;
    public GameObject sideslash;
    public GameObject downslash;
    public PlayerRoll roll;

    bool isDown = false;
    public bool isAttackJumpPossible = true;
    public PlayerMoveMent moveMent;

    public AudioSource knifeSound;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveMent.isStun)
        {
            isAttackKeyDown = Input.GetKeyDown(PlayerPrefs.GetString("AttackKey"));

            if (Input.GetAxisRaw("Vertical") == -1) isDown = true;
            else isDown = false;

            if (moveMent.isClimb || moveMent.isCrouch || roll.isRoll) isAttackPossible = false;
            else isAttackPossible = true;

            //if (isAttackKeyDown && isAttack && isAttackPossible) 
            //else 

            //Debug.Log(isAttack);

            if (isAttackKeyDown && isAttack && isAttackPossible)
            {
                attack = true;
                StartCoroutine(AttackDelay());
                if (isAnimation != null)
                {
                    StopCoroutine(isAnimation);
                }
                isAnimation = StartCoroutine(SlashAnimationPlay());
            }
        }
    }
    IEnumerator AttackDelay()
    {
        isAttack = false;
        yield return new WaitForSeconds(0.4f);
        isAttack = true;
    }

    IEnumerator SlashAnimationPlay()
    {
        isAttackJumpPossible = true;
        anim.SetTrigger("isAttack");
        anim.SetBool("isDown", isDown);
        if (isDown) downslash.SetActive(true);
        else sideslash.SetActive(true);
        knifeSound.Play();
        yield return new WaitForSeconds(0.2f);

        downslash.SetActive(false);
        sideslash.SetActive(false);

        anim.ResetTrigger("isAttack");
        attack = false;
    }
}
