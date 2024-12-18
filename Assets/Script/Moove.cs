using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Moove : MonoBehaviour
{
    public static Moove singleton { get; set; }
    [Header("Анимация")]
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    [Header("Позиция")]
    public float previousYPosition;
    public Transform trans;
    public GameObject SoundListener;
    private Sounds soundSCR;

    public bool death;
    public float lastYpos;

    private CheckGround CheckGrounds;
    public Rigidbody2D rb;
    public float moveSpeed;
    bool isFacingRight = true;
    public float maxVelocityX;
    public float maxVelocityY;

    [Header("Прыжок")]
    public float jumpForce;
    public float reservTimeJump;
    public bool reservTimeJumpPermisison;
    public int jumpCounter = 0;
    public bool isJump;
    public float maxDistance = 50;
    public float timeGroundOut;
    public float timeFallPassed;
    public bool isHigher;

    [Header("Урон")]
    public string names = "HeroeMan";
    public bool runDisabler;
    public bool heroeAtack;
    public float atackJumpForce;

    [Header("Платформа")]
    public bool isOnPlatform;
    public bool isGrounded;
    public PStandart platform;
    public Vector3 pDirection;
    public float pSpeed;
    public float gravityScale;



    private void OnApplicationQuit()
    {
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
    }
    private void HeroeAtack()
    {
        if (heroeAtack == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(trans.position.x, atackJumpForce), ForceMode2D.Impulse);
            heroeAtack = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true || isOnPlatform == true) && (jumpCounter == 0 || jumpCounter == 3))
        {
            rb.linearVelocityY = 0;
            gravityScale = 5f;
            soundSCR.PlaySound(soundSCR.sounds[1]);
            isJump = true;
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter == 1 && reservTimeJumpPermisison == true)
        {
            soundSCR.PlaySound(soundSCR.sounds[1]);
            isJump = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            reservTimeJumpPermisison = false;
            jumpCounter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) && (isGrounded == false && isOnPlatform == false) && jumpCounter == 0)
        {
            jumpCounter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == false && isOnPlatform == false) && jumpCounter == 1 && reservTimeJumpPermisison == false && isJump == true)
        {
            soundSCR.PlaySound(soundSCR.sounds[1]);
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCounter = 3;
        }

    }
    private void JumpAnim()
    {

        float currentYPosition = rb.position.y;
        if (isOnPlatform == true)
        {
            animator.SetInteger("jump", 0);
        }
        else
        {
            // Сравниваем текущую координату "y" с предыдущей
            if (currentYPosition > previousYPosition)
            {
                animator.SetInteger("jump", 1);
            }
            else if (currentYPosition < previousYPosition)
            {
                animator.SetInteger("jump", -1);
            }

            previousYPosition = currentYPosition;
        }
    }
    private void ZYOn()
    {

        if (timeFallPassed > reservTimeJump || reservTimeJumpPermisison == false)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void Run()
    {
        float runSpeed = 0.04f;
        if (runDisabler == false)
        {
            if (Input.GetKeyUp(KeyCode.D) && isGrounded == false)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
                trans.position = new Vector2(transform.position.x + runSpeed, transform.position.y);
                if (isFacingRight == false)
                {
                    isFacingRight = true;

                    Flip();
                }
                return;
            }
            else if (Input.GetKeyUp(KeyCode.A) && isGrounded == false)
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
                transform.position = new Vector2(transform.position.x - runSpeed, transform.position.y);
                if (isFacingRight == true)
                {
                    isFacingRight = false;

                    Flip();
                }
                return;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ЗЕМЛЯ
            if (Input.GetKey(KeyCode.A))
            {
                if (isOnPlatform == true && isHigher == true)
                {
                    rb.linearVelocityX = -maxVelocityX;
                    //rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
                    //rb.linearVelocityX = rb.linearVelocityX + platformRB.linearVelocityX;
                    animator.SetInteger("run", 1);
                    animator.SetBool("isHigher", isHigher);
                }

                else
                {
                    rb.linearVelocityX = -maxVelocityX;
                    rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
                }

                if (isGrounded == true)
                {
                    animator.SetInteger("run", 1);
                }

                if (isFacingRight == true)
                {
                    isFacingRight = false;

                    Flip();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (isOnPlatform == true && isHigher == true)
                {
                    Debug.Log("Бегаем");
                    rb.linearVelocityX = maxVelocityX;
                    //rb.linearVelocityX = rb.linearVelocityX + platformRB.linearVelocityX;
                    animator.SetInteger("run", 1);
                }
                else
                {
                    rb.linearVelocityX = maxVelocityX;
                    rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
                }
                animator.SetInteger("run", 1);
                if (isGrounded == true)
                {
                    animator.SetInteger("run", 1);
                }
                if (isFacingRight == false)
                {
                    isFacingRight = true;

                    Flip();
                }
            }
        }
    }
    private void maxVelocity()
    {
        if (runDisabler == false)
        {

            if (Mathf.Abs(rb.linearVelocityX) > maxVelocityX && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocityX) * maxVelocityX, rb.linearVelocityY);
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isGrounded == true)
            {
                rb.linearVelocity = Vector2.zero;
                animator.SetInteger("run", -1);
            }
            else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isOnPlatform == true)
            {
                animator.SetInteger("run", -1);
            }

        }
        else if (isGrounded == false && maxVelocityY <= rb.linearVelocity.y)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxVelocityY);
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Awake()
    {
        if (!singleton)
        {
            singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        gravityScale = 5;
        rb.gravityScale = gravityScale;
        maxVelocityX = 8f;
        soundSCR = SoundListener.GetComponent<Sounds>();
        heroeAtack = false;
        death = false;
        CheckGrounds = GetComponentInChildren<CheckGround>();
        rb = GetComponent<Rigidbody2D>();
        previousYPosition = rb.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        maxVelocityY = 15;
        atackJumpForce = 50f;
    }

    void Update()
    {
        animator.SetBool("isground", isGrounded);
        animator.SetBool("isOnPlatform", isOnPlatform);
        timeFallPassed = Time.time - timeGroundOut;
        Run();
        maxVelocity();
        Jump();
        JumpAnim();
        ZYOn();
        HeroeAtack();
    }

}

