using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Moove : MonoBehaviour
{
    private Flip Flip;
    public WalkingAirSwitch WalkingAirSwitch;
    public static Moove singleton { get; set; }
    [Header("Анимация")]
    public Animator animator;
    [Header("Позиция")]

    public Transform trans;
    public GameObject SoundListener;
    public bool death;
    public float lastYpos;

    public Rigidbody2D rb;
    public float moveSpeed;
    bool isFacingRight = true;
    public float maxVelocityX;
    public float maxVelocityY;

    [Header("Прыжок")]
    public float maxDistance = 50;
    public bool isHigher;

    [Header("Урон")]
    public bool runDisabler;

    [Header("Платформа")]
    public bool isOnPlatform;
    public bool isGrounded;
    public PStandart platform;
    public Vector3 pDirection;
    public float pSpeed;
    public float gravityScale;



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

                    Flip.FlipBody();
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

                    Flip.FlipBody();
                }
                return;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ЗЕМЛЯ
            if (Input.GetKey(KeyCode.A))
            {
                if (isOnPlatform == true && isHigher == true)
                {
                    rb.linearVelocityX = -maxVelocityX;
                    animator.SetInteger("run", 1);
                    animator.SetBool("isHigher", isHigher);
                }

                else
                {
                    rb.linearVelocityX = -maxVelocityX;
                    rb.linearVelocityX = Vector2.left.x * moveSpeed;
                }



                if (isGrounded == true)
                {
                    animator.SetInteger("run", 1);
                }

                if (isFacingRight == true)
                {
                    isFacingRight = false;

                    Flip.FlipBody();
                }
            }



            else if (Input.GetKey(KeyCode.D))
            {
                if (isOnPlatform == true && isHigher == true)
                {
                    Debug.Log("Бегаем");
                    rb.linearVelocityX = maxVelocityX;
                    animator.SetInteger("run", 1);
                }
                else
                {
                    rb.linearVelocityX = maxVelocityX;
                    rb.linearVelocityX = Vector2.right.x * moveSpeed;
                }
                animator.SetInteger("run", 1);
                if (isGrounded == true)
                {
                    animator.SetInteger("run", 1);
                }
                if (isFacingRight == false)
                {
                    isFacingRight = true;

                    Flip.FlipBody();
                }
            }
        }
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
        Flip = GetComponent<Flip>();
        WalkingAirSwitch = GetComponent<WalkingAirSwitch>();
        gravityScale = 5;
        rb.gravityScale = gravityScale;
        maxVelocityX = 8f;

        death = false;
        rb = GetComponent<Rigidbody2D>();
        
        maxVelocityY = 15;

    }

    void Update()
    {
        animator.SetBool("isOnPlatform", isOnPlatform);
        animator.SetBool("isground", isGrounded);
        Run();
        WalkingAirSwitch.ZYOn();
    }
}