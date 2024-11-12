using Unity.VisualScripting;
using UnityEngine;

public class Moove : MonoBehaviour
{
    [Header("Анимация")]
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    [Header("Позиция")]
    public float previousYPosition;
    public Transform trans;

    public float lastYpos;

    private CheckGround CheckGrounds;
    public Rigidbody2D rb;
    public float moveSpeed;
    bool isFacingRight = true;
    public float jumpForce;
    public bool isGrounded;
    public float maxVelocityX;
    public int jumpCounter = 0;

    public float maxDistance = 50;

    public float timeGroundOut;
    public float timeFallPassed;
    public float reservTimeJump;
    public bool reservTimeJumpPermisison;
    public bool isJump;

    [Header("Урон")]
    public bool damageSwitcher;
    public string names = "asdadasdasd";
    public int healch;
    public int damage;
    public Vector2 damagerPosition;
    public float damageTime;
    public float ghostTimer;
    public float ghostTime;
    public bool runDisabler;
    public float kickForce;
    public float alpha;

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

            if (ghostTimer >= ghostTime)
            {
                SetColor(new Color(1f, 1f, 1f, 1));
                damageSwitcher = false;
                runDisabler = false;
                alpha = 1;
            }
        }
    }
    private void Damage()
    {
        if (damage != 0)
        {
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
                rb.AddForce(new Vector2(kickForce, kickForce), ForceMode2D.Impulse);
            }

        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && (jumpCounter == 0 || jumpCounter == 3))
        {
            isJump = true;
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Прыг1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter == 1 && reservTimeJumpPermisison == true)
        {
            isJump = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            reservTimeJumpPermisison = false;
            jumpCounter = 0;
            Debug.Log("Прыг2");
        }

        if (Input.GetKeyUp(KeyCode.Space) && isGrounded == false && jumpCounter == 0)
        {
            jumpCounter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && jumpCounter == 1 && reservTimeJumpPermisison == false && isJump == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCounter = 3;
        }

    }

    private void JumpAnim()
    {

        float currentYPosition = rb.position.y;

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
        if (runDisabler == false)
        {

            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
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
                rb.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
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
        if (Mathf.Abs(rb.linearVelocityX) > maxVelocityX && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocityX) * maxVelocityX, rb.linearVelocityY);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && isGrounded == true)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetInteger("run", -1);
        }
    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void Start()
    {
        alpha = 0.7f;
        damageSwitcher = false;
        healch = 3;
        damage = 0;
        ghostTime = 0.3f;
        kickForce = 50;
        damagerPosition = Vector3.zero;
        CheckGrounds = GetComponentInChildren<CheckGround>();
        rb = GetComponent<Rigidbody2D>();
        previousYPosition = rb.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timeFallPassed = Time.time - timeGroundOut;
        animator.SetBool("isground", isGrounded);
        Run();
        maxVelocity();
        Jump();
        JumpAnim();
        ZYOn();
        Damage();
        GhostTimer();
    }

}

