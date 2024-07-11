using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WolfAttack : MonoBehaviour
{
    bool thisTurnLeft = false; //true면 left, false면 right 
    bool wolfDie = false;
    float walkSpeed = 5f;
    public WolfStateMachine stateMachine;
    
    float waitAttack = 1.2f;
    Animator anim;

    public GameObject howling;
    public GameObject attack1;
    public GameObject attack2;

    public AudioSource attackSound;
    public AudioSource runSound;
    public AudioSource howlingSound;
    #region Postion
    public Transform LeftWaitZone;
    public Transform RightWaitZone;
    public Transform LeftAttackZone;
    public Transform RightAttackZone;
    #endregion
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.isDie && !wolfDie)
        {
            wolfDie = true;
            wolfAttackStop();
        }   
    }

    void wolfAttackStop()
    {
        StopAllCoroutines();
        howling.SetActive(false);
        attack1.SetActive(false);
        attack2.SetActive(false);
        anim.SetTrigger("die");
    }
    public void BossStart()
    {
        if (!stateMachine.isDie) SelectLeftorRight();
    }

    void SelectLeftorRight()
    {
        int[] left_right = { -1, 1 };
        int randomSign = left_right[Random.Range(0, left_right.Length)];
        if (randomSign == -1)
        {
            //Debug.Log("left");
            thisTurnLeft = true;
            TurnLeft();
        }
        else
        {
            //Debug.Log("right");
            thisTurnLeft = false;
            TurnRight();
        }
    }

    void TurnLeft()
    {
        transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        transform.position = LeftWaitZone.position;
        //walk animation
        StartCoroutine(MoveWaitToAttackZone_Left());
    }

    void TurnRight()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f); ;
        transform.position = RightWaitZone.position;
        //walk animation
        StartCoroutine (MoveWaitToAttackZone_Right());
    }
    
    IEnumerator MoveWaitToAttackZone_Left()
    {
        float distanceToTarget = Mathf.Abs(transform.position.x - LeftAttackZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, LeftAttackZone.position.x, walkSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - LeftAttackZone.position.x);

            yield return null;
        }

        transform.position = new Vector3(LeftAttackZone.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.2f);
        SelectAttackType();
    }

    IEnumerator MoveWaitToAttackZone_Right()
    {
        float distanceToTarget = Mathf.Abs(transform.position.x - RightAttackZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, RightAttackZone.position.x, walkSpeed * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - RightAttackZone.position.x);

            yield return null;
        }

        transform.position = new Vector3(RightAttackZone.position.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(0.2f);
        SelectAttackType();
    }

    void SelectAttackType()
    {
        int[] left_right = { -1, 0, 1 };
        int randomSign = left_right[Random.Range(0, left_right.Length)];

        if (randomSign == -1) // 돌진_Red
        {
            if (thisTurnLeft) StartCoroutine(Left_Run_Red());
            else StartCoroutine(Right_Run_Red());
        }
        else if (randomSign == 0) // 하울링_Yellow
        {
            if (thisTurnLeft) StartCoroutine(Left_Howling_Yellow());
            else StartCoroutine(Right_Howling_Yellow());
        }
        else // 할퀴기_Purple
        {
            if (thisTurnLeft) StartCoroutine(Left_Attack_Purple());
            else StartCoroutine(Right_Attack_Purple());
        }
    }

    IEnumerator Left_Run_Red()
    {
        // 왼쪽에서 오른쪽으로
        //Debug.Log("왼쪽 돌진");
        anim.SetBool("is_run", true);
        attackSound.Play();
        yield return new WaitForSeconds(waitAttack);
        anim.SetBool("start", true);
        float distanceToTarget = Mathf.Abs(transform.position.x - RightWaitZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, RightWaitZone.position.x, walkSpeed * 7f * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - RightWaitZone.position.x);

            yield return null;
        }
        attackSound.Stop();
        transform.position = new Vector3(RightWaitZone.position.x, transform.position.y, transform.position.z);
        //yield return new WaitForSeconds(0.2f);
        anim.SetBool("is_run", false);
        anim.SetBool("start", false);
        BossStart();
    }
    IEnumerator Right_Run_Red()
    {
        // 오른쪽에서 왼쪽으로
        //Debug.Log("오른쪽 돌진");
        anim.SetBool("is_run", true);
        attackSound.Play();
        yield return new WaitForSeconds(waitAttack);
        
        anim.SetBool("start", true);

        float distanceToTarget = Mathf.Abs(transform.position.x - LeftWaitZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, LeftWaitZone.position.x, walkSpeed * 7f * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - LeftWaitZone.position.x);

            yield return null;
        }
        attackSound.Stop();
        transform.position = new Vector3(LeftWaitZone.position.x, transform.position.y, transform.position.z);
        //yield return new WaitForSeconds(0.2f);
        anim.SetBool("is_run", false);
        anim.SetBool("start", false);
        BossStart();
    }
    IEnumerator Left_Howling_Yellow()
    {
        //Debug.Log("왼쪽 하울링");
        anim.SetBool("is_howling", true);
        yield return new WaitForSeconds(waitAttack + 1f);

        howlingSound.Play();
        anim.SetBool("start", true);
        howling.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        anim.SetBool("is_howling", false);
        anim.SetBool("start", false);
        howling.SetActive(false);

        StartCoroutine(MoveAttackToWaitkZone_Left());
    }
    IEnumerator Right_Howling_Yellow()
    {
        //Debug.Log("오른쪽 하울링");
        anim.SetBool("is_howling", true);
        yield return new WaitForSeconds(waitAttack + 1f);

        howlingSound.Play();
        anim.SetBool("start", true);
        howling.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        anim.SetBool("is_howling", false);
        anim.SetBool("start", false);
        howling.SetActive(false);

        StartCoroutine(MoveAttackToWaitkZone_Right());
    }
    IEnumerator Left_Attack_Purple()
    {
        //Debug.Log("왼쪽 할퀴기");
        anim.SetBool("is_attack", true);
        yield return new WaitForSeconds(waitAttack);

        attackSound.Play();
        anim.SetBool("start", true);
        attack1.SetActive(true);
        yield return new WaitForSeconds(1f);
        attack2.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("is_attack", false);
        anim.SetBool("start", false);
        attack1.SetActive(false);
        attack2.SetActive(false);

        StartCoroutine(MoveAttackToWaitkZone_Left());
    }
    IEnumerator Right_Attack_Purple()
    {
        //Debug.Log("오른쪽 할퀴기");
        anim.SetBool("is_attack", true);
        yield return new WaitForSeconds(waitAttack);

        attackSound.Play();
        anim.SetBool("start", true);
        attack2.SetActive(true);
        yield return new WaitForSeconds(1f);
        attack1.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        anim.SetBool("is_attack", false);
        anim.SetBool("start", false);
        attack1.SetActive(false);
        attack2.SetActive(false);

        StartCoroutine(MoveAttackToWaitkZone_Right());
    }

    IEnumerator MoveAttackToWaitkZone_Left()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        float distanceToTarget = Mathf.Abs(transform.position.x - LeftWaitZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, LeftWaitZone.position.x, walkSpeed * 4f * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - LeftWaitZone.position.x);

            yield return null;
        }

        transform.position = new Vector3(LeftWaitZone.position.x, transform.position.y, transform.position.z);

        BossStart();
    }

    IEnumerator MoveAttackToWaitkZone_Right()
    {
        transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        float distanceToTarget = Mathf.Abs(transform.position.x - RightWaitZone.position.x);

        while (distanceToTarget > 0.5f)
        {
            float newX = Mathf.MoveTowards(transform.position.x, RightWaitZone.position.x, walkSpeed * 4f * Time.deltaTime);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            distanceToTarget = Mathf.Abs(transform.position.x - RightWaitZone.position.x);

            yield return null;
        }

        transform.position = new Vector3(RightWaitZone.position.x, transform.position.y, transform.position.z);
        
        BossStart();

    }
}