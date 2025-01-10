using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    private float maxVelocityX;
    private float maxVelocityY;
    private void SetVelocityLimitX()
    {
        if (Moove.singleton.runDisabler == false)
        {

            if (Mathf.Abs(Moove.singleton.rb.linearVelocityX) > maxVelocityX && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                Moove.singleton.rb.linearVelocity = new Vector2(Mathf.Sign(Moove.singleton.rb.linearVelocityX) * maxVelocityX, Moove.singleton.rb.linearVelocityY);
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Moove.singleton.isGrounded == true)
            {
                Moove.singleton.rb.linearVelocity = Vector2.zero;
                Moove.singleton.animator.SetInteger("run", -1);
            }
            else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && Moove.singleton.isOnPlatform == true)
            {
                Moove.singleton.animator.SetInteger("run", -1);
            }

        }
        else if (Moove.singleton.isGrounded == false && maxVelocityY <= Moove.singleton.rb.linearVelocity.y)
        {
            Moove.singleton.rb.linearVelocity = new Vector2(Moove.singleton.rb.linearVelocity.x, maxVelocityY);
        }
    }
    void Start()
    {
        maxVelocityX = Moove.singleton.maxVelocityX;
        maxVelocityY = Moove.singleton.maxVelocityY;
    }
    private void Update()
    {
        SetVelocityLimitX();
    }
}
