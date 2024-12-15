using Unity.VisualScripting;
using UnityEngine;

public class MooveMushroom : MonoBehaviour, IEnemy
{
    private GameObject heroe;
    private Transform enemyTransform;
    private string enemyName = "Mooshroom";
    private int enemyHealch = 1;
    private int enemyDamage = 1;
    [SerializeField] private float enemySpeed = 8f;
    private Rigidbody2D enemyRigidbody;
    [SerializeField] private float enemyMaxVelocityX = 2;
    private float enemyMaxVelocityY = 2;
    [SerializeField] private float raycastDistance = 1.1f; // Расстояние для проверки земли под ногами
    [SerializeField] private LayerMask groundLayer; // Слой, на котором находится земля

    public GameObject Heroe => heroe;
    public Transform EnemyTransform => enemyTransform;
    public Rigidbody2D EnemyRigidbody => enemyRigidbody;
    public string EnemyName => enemyName;
    public int EnemyHealch => enemyHealch;
    public int EnemyDamage => enemyDamage;
    public float EnemySpeed => enemySpeed;
    public float EnemyMaxVelocityX => enemyMaxVelocityX;
    public float EnemyMaxVelocityY => enemyMaxVelocityY;
    private string enemyMooveDirection;
    private bool checkGrounded;
    public bool leftCollision;
    public bool rightCollision;

    bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(EnemyTransform.position, Vector2.down * raycastDistance, Color.red);
        if (hit.collider != null && hit.collider.name != "Confiner2D")
        {
            return true; // Персонаж стоит на земле
        }
        return false; // Персонаж не стоит на земле

    }



    private void DirectionSwitcher()

    {
        if (leftCollision == true && checkGrounded == true)
        {
            enemyMooveDirection = "RIGHT";
            leftCollision = false;
        }
        else if (rightCollision == true && checkGrounded == true)
        {
            enemyMooveDirection = "LEFT";
            rightCollision = false;
        }

        else if (enemyMooveDirection == "RIGHT" && checkGrounded == false)
        {
            EnemyRigidbody.linearVelocity = new Vector2(-2, 0);
            enemyMooveDirection = "LEFT";
        }
        else if (enemyMooveDirection == "LEFT" && checkGrounded == false)
        {
            EnemyRigidbody.linearVelocity = new Vector2(2, 0);
            enemyMooveDirection = "RIGHT";
        }
    }
    private void NoneSthopRun()
    {
        if (enemyMooveDirection == "RIGHT")
        {
            EnemyRun(Vector2.right);
        }
        else if (enemyMooveDirection == "LEFT")
        {
            EnemyRun(Vector2.left);
        }
    }

    private void MaxVelocity()
    {
        if (Mathf.Abs(EnemyRigidbody.linearVelocityX) > EnemyMaxVelocityX)
        {
            EnemyRigidbody.linearVelocity = new Vector2(Mathf.Sign(EnemyRigidbody.linearVelocityX) * EnemyMaxVelocityX, EnemyRigidbody.linearVelocityY);
        }

    }
    public void EnemyCollisions()
    {
    }

    private void EnemyRun(Vector2 direction)
    {
        EnemyRigidbody.AddForce(direction * EnemySpeed, ForceMode2D.Impulse);

    }
    void Start()
    {
        leftCollision = false;
        rightCollision = false;
        heroe = GameObject.Find("He roe");
        enemyTransform = GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyMooveDirection = "RIGHT";
        checkGrounded = true;
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        NoneSthopRun();
        MaxVelocity();
        checkGrounded = CheckGrounded();
        DirectionSwitcher();

    }
}
