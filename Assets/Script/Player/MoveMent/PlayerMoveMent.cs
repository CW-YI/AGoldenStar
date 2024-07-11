using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;

    public PlayerStateMachine playerState;
    bool isGround = false;
    #region walk&run
    [SerializeField] private float maxWalkSpeed = 8f;
    [SerializeField] private float maxRunSpeed = 20f;
    public bool isRun = false;
    public bool isWalk = false;
    #endregion

    #region jump
    public float jumpPower = 22f;
    public bool isJump = false;
    public bool isJumpPossible = true;
    int maxJump = 2;
    public int nowJump = 0;
    public bool jumpUP;
    //public double drag = 3;
    #endregion

    #region crouch
    [SerializeField] private float maxCrouchSpeed = 4f;
    public bool isCrouch = false;
    #endregion

    #region climb
    [SerializeField] private float maxClimbSpeed = 1.5f;
    private float moveClimbSpeed = 1.5f;
    public bool isClimbPossible = false;
    public bool isClimb = false;
    public bool isClimbJump = true;
    #endregion

    #region roll
    public bool isRoll = false;
    #endregion

    public bool isStun = false;

    public AudioSource jumpSound;
    public AudioSource walkSound;

    bool downJumpFix = false;
    bool upJumpFix = false;
    bool climbFix = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (!PlayerPrefs.HasKey("RunKey")) PlayerPrefs.SetString("RunKey", "left shift");
        if (!PlayerPrefs.HasKey("JumpKey")) PlayerPrefs.SetString("JumpKey", "space");
        if (!PlayerPrefs.HasKey("ClimbKey")) PlayerPrefs.SetString("ClimbKey", "z");
        if (!PlayerPrefs.HasKey("CrouchKey")) PlayerPrefs.SetString("CrouchKey", "c");
        if (!PlayerPrefs.HasKey("InteractionKey")) PlayerPrefs.SetString("InteractionKey", "a");
        if (!PlayerPrefs.HasKey("AttackKey")) PlayerPrefs.SetString("AttackKey", "left ctrl");
        //if (!PlayerPrefs.HasKey("RollKey")) PlayerPrefs.SetString("RollKey", "x");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(PlayerPrefs.GetString("JumpKey")) && !isClimb && isJump && !playerState.isDie)
        {
            //°³¹ß0.2f ºôµå 1.0f 0.9f
            //rigid.AddForce(Vector2.down * 0.2f, ForceMode2D.Impulse);
            //rigid.AddForce(Vector2.down * 0.3f, ForceMode2D.Impulse);
            downJumpFix = true;
        }
        else downJumpFix = false;
        if (!playerState.isDie && !isStun)
        {
            if (Input.GetKeyDown(PlayerPrefs.GetString("JumpKey")) && nowJump < maxJump && !isJump)
            {
                upJumpFix = true;

                rigid.AddForce(Vector2.up * jumpPower * 1.5f, ForceMode2D.Impulse);
                jumpSound.Play();
                jumpUP = true;
                nowJump += 1;
            }
            else { jumpUP = false; upJumpFix = false; }

            if (isClimb && Input.GetKey(PlayerPrefs.GetString("JumpKey")) && isClimbJump)
            {
                climbFix = true;
                rigid.velocity = new Vector2(transform.localScale.x * jumpPower * 0.8f, 0.7f * jumpPower);
                isStun = true;
                transform.localScale = new Vector3(transform.localScale.x * (-1f), 1, 1);
                isClimbJump = false;
                Invoke("IsClibJumpTrue", 0.3f);
            }
            else climbFix = false;

            if (Input.GetButtonUp("Horizontal")) // ¸ØÃã
            {
                isWalk = false;
                //walkSound.Stop();
                rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
            }

            if (Input.GetButton("Horizontal") )//&& !isClimb)
            {
                isWalk = true;
                //if (!walkSound.isPlaying) walkSound.Play();

                if (Input.GetAxisRaw("Horizontal") == -1) transform.localScale = new Vector3(1, 1, 1); // ¿ÞÂÊ
                else transform.localScale = new Vector3(-1, 1, 1); // ¿À¸¥ÂÊ
            }
            if (Input.GetButtonUp("Vertical") && isClimb)
            {
                float y = Input.GetAxisRaw("Vertical");
                rigid.velocity = new Vector2(rigid.velocity.normalized.x, rigid.velocity.y * 0.5f);
            }
            if (Mathf.Abs(rigid.velocity.x) < 0.3)
            {
                isRun = isWalk = isCrouch = false;
            }

            isRun = Input.GetKey(PlayerPrefs.GetString("RunKey"));
            isCrouch = Input.GetKey(PlayerPrefs.GetString("CrouchKey"));
            if (isClimbPossible && !Input.GetKey(PlayerPrefs.GetString("JumpKey"))) isClimb = Input.GetKey(PlayerPrefs.GetString("ClimbKey"));
            else isClimb = false;

            if (isClimb) isJump = false;
            if (isCrouch) isRun = false;
            PlayAnimation();

            if (isClimb) rigid.gravityScale = 0f;
            else rigid.gravityScale = 2.5f;
        }
        else if (isStun)
        {
            isClimb = isWalk = isRun = isCrouch = false; // isJump
            PlayAnimation();
        }
    }

    void FixedUpdate()
    {
        if (downJumpFix) rigid.AddForce(Vector2.down * 0.85f, ForceMode2D.Impulse);
        if (!playerState.isDie && !isStun)
        {
            if (upJumpFix)
            {
                //rigid.AddForce(Vector2.up * jumpPower * 1.5f, ForceMode2D.Impulse);
            }
            if (climbFix)
            {
                //rigid.velocity = new Vector2(transform.localScale.x * jumpPower * 0.8f, 0.7f * jumpPower);
            }


            float h = Input.GetAxisRaw("Horizontal");
            //walkSound.Play();
            float maxSpeed = isRun ? maxRunSpeed : maxWalkSpeed;
            if (isCrouch) maxSpeed = maxCrouchSpeed;
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            
            if (rigid.velocity.x > maxWalkSpeed) rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); // ¿À¸¥ÂÊ ÃÖ´ë¼Óµµ
            else if (rigid.velocity.x < maxWalkSpeed * (-1)) rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); // ¿ÞÂÊ ÃÖ´ë¼Óµµ


            if (isClimb)
            {
                float y = Input.GetAxisRaw("Vertical");

                maxSpeed = maxClimbSpeed;
                //if (y == 1) moveClimbSpeed = 1.5f;
                //else moveClimbSpeed = 0.5f;

                rigid.AddForce(Vector2.up * y * moveClimbSpeed, ForceMode2D.Impulse);
                //Vector2 moveVelocity = new Vector2(rigid.velocity.x, y) * maxSpeed * Time.deltaTime;

                if (rigid.velocity.y > maxSpeed) rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed);
                else if (rigid.velocity.y < maxSpeed * (-1)) rigid.velocity = new Vector2(rigid.velocity.x, maxSpeed * (-1));
            }
        }
    }

    void IsClibJumpTrue()
    {
        //isClimbJump = true;
        isStun = false;
    }
    void PlayAnimation()
    {
        anim.SetBool("isClimb", isClimb);
        anim.SetBool("isWalk", isWalk);
        anim.SetBool("isJump", isJump);
        anim.SetBool("isRun", isRun);
        anim.SetBool("isCrouch", isCrouch);
        
        //anim.SetBool("isGrab", isGrab);
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    void OnCollisionStay2D(Collision2D collision)
    {
       
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       
    }
}
