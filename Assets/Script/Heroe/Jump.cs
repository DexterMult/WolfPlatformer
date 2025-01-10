using UnityEngine;

public class Jump : MonoBehaviour
{
    public int jumpCounter = 0;
    public bool reservTimeJumpPermisison;
    public bool isJump;
    private Sounds soundSCR;
    public GameObject SoundListener;
    public float jumpForce;
    public float reservTimeJump;
    private void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Moove.singleton.isGrounded == true || Moove.singleton.isOnPlatform == true) && (jumpCounter == 0 || jumpCounter == 3))
        {
            Moove.singleton.rb.linearVelocityY = 0;
            Moove.singleton.gravityScale = 5f;
            soundSCR.PlaySound(soundSCR.sounds[1]);
            isJump = true;
            Moove.singleton.isGrounded = false;
            Moove.singleton.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter == 1 && reservTimeJumpPermisison == true)
        {
            soundSCR.PlaySound(soundSCR.sounds[1]);
            isJump = true;
            Moove.singleton.rb.constraints = RigidbodyConstraints2D.None;
            Moove.singleton.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Moove.singleton.rb.linearVelocity = new Vector2(Moove.singleton.rb.linearVelocityX, 0);
            Moove.singleton.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            reservTimeJumpPermisison = false;
            jumpCounter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) && (Moove.singleton.isGrounded == false && Moove.singleton.isOnPlatform == false) && jumpCounter == 0)
        {
            jumpCounter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (Moove.singleton.isGrounded == false && Moove.singleton.isOnPlatform == false) && jumpCounter == 1 && reservTimeJumpPermisison == false && isJump == true)
        {
            soundSCR.PlaySound(soundSCR.sounds[1]);
            Moove.singleton.rb.linearVelocity = new Vector2(Moove.singleton.rb.linearVelocityX, 0);
            Moove.singleton.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpCounter = 3;
        }

    }
    void Start()
    {
        jumpForce = 50f;
        soundSCR = SoundListener.GetComponent<Sounds>();
    }

    void Update()
    {
        JumpUp();
    }
}
