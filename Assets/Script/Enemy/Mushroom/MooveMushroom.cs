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
    [SerializeField] private float raycastDistance = 1.1f; // ���������� ��� �������� ����� ��� ������
    [SerializeField] private LayerMask groundLayer; // ����, �� ������� ��������� �����

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
    private bool oneCollisionIgnored;
    public bool leftCollision;
    public bool rightCollision;
    bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(EnemyTransform.position, Vector2.down * raycastDistance, Color.red);
        if (hit.collider != null)
        {
            //Debug.Log("�����: " + hit.distance);
            return true; // �������� ����� �� �����
        }
        //Debug.Log("������");
        return false; // �������� �� ����� �� �����

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //    //������� ���� ���������� �����
        //    if (oneCollisionIgnored == false) { 
        //    foreach (ContactPoint2D contact in collision.contacts)
        //    {
        //        //����������� ����� �������� � �������
        //        Debug.Log("������������ ��������� � �����: " + contact.point);
        //        //����� �� ������ �������� ���� ������ ��� ��������� ������������
        //        if (EnemyTransform.position.x < contact.point.x)
        //        {
        //            Debug.Log("����� �����");
        //            enemyMooveDirection = "LEFT";
        //        }
        //        else if (EnemyTransform.position.x > contact.point.x)
        //        {
        //            enemyMooveDirection = "RIGHT";
        //        }
        //    }
        //}
        //    if (oneCollisionIgnored == true && collision.contacts != null)
        //    {
        //        oneCollisionIgnored = false;
        //    }
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

        if (enemyMooveDirection == "RIGHT" && checkGrounded == false)
        {
            EnemyRigidbody.linearVelocity = new Vector2(-2, 0);
            enemyMooveDirection = "LEFT";
            Debug.Log("����");
        }
        else if (enemyMooveDirection == "LEFT" && checkGrounded == false)
        {
            EnemyRigidbody.linearVelocity = new Vector2(2, 0);
            enemyMooveDirection = "RIGHT";
            Debug.Log("����");
        }
    }
    private void NoneSthopRun()
    {
        if (enemyMooveDirection == "RIGHT")
        {
            EnemyRun(Vector2.right);
        }
        if (enemyMooveDirection == "LEFT")
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
        oneCollisionIgnored = true;
        heroe = GameObject.Find("Heroe");
        enemyTransform = GetComponent<Transform>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyMooveDirection = "RIGHT";
        checkGrounded = true;
    }

    void Update()
    {
        //Debug.Log(checkGrounded);
        NoneSthopRun();
        MaxVelocity();
    }
    void FixedUpdate()
    {
        checkGrounded = CheckGrounded();
        DirectionSwitcher();

    }
}
