using UnityEngine;

public class JumpLeftOrRight : MonoBehaviour
{
    private GroundChecker groundChecker;
    private float jumpForce;
    private Rigidbody2D rigidbody2;

    private void SetJumpLeftOrRight()
    {
        if (groundChecker.isEnemyRight == true)
        {
            rigidbody2.linearVelocityX = 0;
            rigidbody2.linearVelocityY = 0;
            groundChecker.SetIsEnemyRight(false);
            groundChecker.SetFall(false);
            groundChecker.SetJump(false);
            JumpLeft();
        }
        else if(groundChecker.isEnemyLeft == true)
        {
            rigidbody2.linearVelocityX = 0;
            rigidbody2.linearVelocityY = 0;
            groundChecker.SetIsEnemyLeft(false);
            groundChecker.SetFall(false);
            groundChecker.SetJump(false);
            JumpRight();
        }
    }
    private void JumpLeft()
    {
        rigidbody2.AddForce(new Vector2(-jumpForce,jumpForce), ForceMode2D.Impulse);
    }
    private void JumpRight()
    {
        rigidbody2.AddForce(new Vector2(jumpForce,jumpForce), ForceMode2D.Impulse);
    }
    void Start()
    {
        groundChecker = GetComponent<GroundChecker>();
        rigidbody2 = GetComponent<Rigidbody2D>();
        jumpForce = 50;
    }

    void Update()
    {
        SetJumpLeftOrRight();
    }
}
