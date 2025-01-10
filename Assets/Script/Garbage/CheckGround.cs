using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Transform trans;
    public GameObject Heroe;
    public Jump Jump;
    public int jumpCounter;
    public bool isGround;
    public float timeGroundOut;
    public float raycastDistance;
    public WalkingAirSwitch WalkingAirSwitch;

    public GameObject SoundListener;
    private Sounds soundSCR;

    public Rigidbody2D rigidbodys;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground0") || collision.gameObject.CompareTag("ThornsTag"))
        {
            isGround = true;
            soundSCR.PlaySound(soundSCR.sounds[2], volume: 0.6f);
            jumpCounter = 0;
            getGround();
            getCounter();
            Jump.reservTimeJumpPermisison = false;
            Jump.isJump = false;
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground0") || collision.gameObject.CompareTag("ThornsTag") || collision.gameObject.CompareTag("PlatformTag"))
        {
            isGround = false;
            jumpCounter = 1;
            getGround();
            getCounter();
            GetTime();
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && isGround == false && Jump.reservTimeJumpPermisison == false && Jump.isJump == false)
            {
                Jump.reservTimeJumpPermisison = true;
                rigidbodys.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && Moove.singleton.isOnPlatform == false && Moove.singleton.isHigher == true 
                && Jump.reservTimeJumpPermisison == false && Jump.isJump == true)
            {
                Jump.reservTimeJumpPermisison = true;
                rigidbodys.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
    private void RaycastLeftRightChecker()
    {
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(trans.position, Vector2.down, raycastDistance);
        Debug.DrawRay(trans.position, Vector2.down * raycastDistance, Color.red);
        foreach (RaycastHit2D hit in hitsLeft)
        {
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                string hitObjectTag = hitObject.tag;
                if (hitObjectTag == "ThornsTag")
                {
                    isGround = true;
                    jumpCounter = 0;
                    getGround();
                    getCounter();
                    Jump.reservTimeJumpPermisison = false;
                    Jump.isJump = false;
                }
            }
        }
    }

    public float GetTime()
    {
        return WalkingAirSwitch.timeGroundOut = Time.time;
    }
    public bool getGround()
    {
        return Moove.singleton.isGrounded = isGround;
    }

    public int getCounter()
    {

        return Jump.jumpCounter = jumpCounter;
    }
    void Start()
    {
        soundSCR = SoundListener.GetComponent<Sounds>();
        raycastDistance = 1.2f;
    }


    void Update()
    {
        RaycastLeftRightChecker();

    }
}
