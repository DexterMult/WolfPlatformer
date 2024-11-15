using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Transform trans;
    public Object Heroe;
    Moove moveScript;
    public int jumpCounter;
    public bool isGround;
    public float timeGroundOut;

    public Rigidbody2D rigidbodys;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground0"))
        {
            isGround = true;
            jumpCounter = 0;
            getGround();
            getCounter();
            moveScript.reservTimeJumpPermisison = false;
            moveScript.isJump = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground0"))
        {
            isGround = false;
            jumpCounter = 1;
            getGround();
            getCounter();
            GetTime();
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && isGround == false && moveScript.reservTimeJumpPermisison == false && moveScript.isJump == false)
            {
                moveScript.reservTimeJumpPermisison = true;
                rigidbodys.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    public float GetTime()
    {
        return moveScript.timeGroundOut = Time.time;
    }
    public bool getGround()
    {
        return moveScript.isGrounded = isGround;
    }

    public int getCounter()
    {

        return moveScript.jumpCounter = jumpCounter;
    }
    void Start()
    {
        moveScript = GetComponentInParent<Moove>();
    }

    void Update()
    {

    }
}
