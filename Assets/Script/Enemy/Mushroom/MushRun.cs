using Unity.Mathematics;
using UnityEngine;

public class MushRun : MonoBehaviour
{
    private Collider2D collider2;
    private MushDestroy mushDestroy;
    [SerializeField]private float speed;
    private Rigidbody2D rigidbody2;

    private bool isGround;
    public float rayLRDistance;
    private float rayDownDistance;
    public LayerMask layerMask;


    private void SetRun()
    {
        rigidbody2.linearVelocityX = speed;
    }


    private void RayRightChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, rayLRDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * rayLRDistance, Color.red);
        
        if (hit == true && speed >0)
        {
            speed = speed * (-1);
        }
    }
    private void RayLeftChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayLRDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * rayLRDistance, Color.red);

        if (hit == true && speed < 0)
        {
            speed = speed * (-1);
        }
    }    
    private void RayDownChecker()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDownDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * rayDownDistance, Color.red);
        if (hit == false && isGround == true)
        {
            speed = speed * (-1);
            isGround = false;
        }
        else if(hit == true) { isGround = true; }
    }
    void Start()
    {
        rayLRDistance = 0.6f;
        rayDownDistance = 1f;
        rigidbody2 = GetComponent<Rigidbody2D>();
        collider2 = GetComponent<Collider2D>(); 
    }

    void Update()
    {
        SetRun();
        RayRightChecker();
        RayLeftChecker();
        RayDownChecker();
    }
}
