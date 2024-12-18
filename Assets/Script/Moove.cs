using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Moove : MonoBehaviour
{
    public static Moove singleton { get; set; }
    private Healch Healch;
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
    public bool damageSwitcher;
    public string names = "HeroeMan";
    public int healch;
    public int damage;
    public Vector2 damagerPosition;
    public float damageTime;
    public bool damagePermission;
    public float ghostTimer;
    public float ghostTime;
    public float reservGhostTime;
    public bool runDisabler;
    public float kickForce;
    public float alpha;
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
    public void SetColor(Color color)
    {

        spriteRenderer.color = color; // Установка нового цвета
    }
    public void SetTransparency(float alpha)
    {

        Color color = spriteRenderer.color;
        color.a = Mathf.Clamp01(alpha); // Убедитесь, что значение находится в диапазоне от 0 до 1
        spriteRenderer.color = color;
    }
    private void GhostTimer()
    {


        if (damageSwitcher == true)
        {
            alpha = 0.5f;
            SetColor(new Color(1f, 0f, 0f, alpha));
            ghostTimer = Time.time - damageTime;

            if (reservGhostTime <= ghostTimer)
            {
                SetColor(new Color(1f, 1f, 1f, 1));
                alpha = 1;
                damageSwitcher = false;
                return;
            }
            else if (ghostTimer >= ghostTime)
            {
                runDisabler = false;
            }
        }
    }
    private void Damage()
    {

        if (damagePermission == false)
        {
            float Timerok = Time.time - (reservGhostTime + damageTime);
            if (Timerok >= reservGhostTime)
            {
                damagePermission = true;
            }
        }

        if (damage != 0)
        {
            soundSCR.PlaySound(soundSCR.sounds[3]);
            damagePermission = false;
            Healch.HitPoints = healch - damage;
            healch = healch - damage;
            damage = 0;
            if (damagerPosition.x > trans.position.x)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(new Vector2(-kickForce, kickForce), ForceMode2D.Impulse);
            }
            else if (damagerPosition.x < trans.position.x)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(new Vector2(+kickForce, kickForce), ForceMode2D.Impulse);
            }

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
        Healch = GetComponent<Healch>();
        damagePermission = true;
        damageTime = 0;
        heroeAtack = false;
        death = false;
        alpha = 0.7f;
        damageSwitcher = false;
        healch = 3;
        damage = 0;
        ghostTime = 0.3f;
        reservGhostTime = 1f;
        kickForce = 50;
        damagerPosition = Vector3.zero;
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
        Damage();
        Run();
        maxVelocity();
        Jump();
        JumpAnim();
        ZYOn();
        GhostTimer();
        HeroeAtack();
    }

}

