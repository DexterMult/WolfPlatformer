using UnityEngine;
using UnityEngine.UIElements;

public class RunHedgehog : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2;

    private bool isGround;
    private float rayLRDistance;
    private float rayDownDistance;
    public LayerMask layerMask;
    private void SetRun()
    {
        rigidbody2.linearVelocityX = speed;
    }


    private void RayRightChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.right, rayLRDistance, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.right * rayLRDistance, Color.red);

        if (hit == true && speed > 0)
        {
            speed = speed * (-1);
            Flip();
        }
    }
    private void RayLeftChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.left, rayLRDistance, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.left * rayLRDistance, Color.red);

        if (hit == true && speed < 0)
        {
            speed = speed * (-1);
            Flip();
        }
    }
    private void RayDownChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y - 0.25f), Vector2.down, rayDownDistance, layerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.down * rayDownDistance, Color.red);
        if (hit == false && isGround == true)
        {
            speed = speed * (-1);
            isGround = false;
            Flip();
        }
        else if (hit == true) { isGround = true; }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
    void Start()
    {
        rayLRDistance = 0.7f;
        rayDownDistance = 1f;
        speed = 5f;
        rigidbody2 = GetComponent<Rigidbody2D>();
        Flip();
    }

    void Update()
    {
        SetRun();
        RayRightChecker();
        RayLeftChecker();
        RayDownChecker();
    }
}
