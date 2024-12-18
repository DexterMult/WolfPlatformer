using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public Transform trans;
    public GameObject Heroe;
    Moove moveScript;
    public int jumpCounter;
    public bool isGround;
    public float timeGroundOut;
    public float raycastDistance;

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
            moveScript.reservTimeJumpPermisison = false;
            moveScript.isJump = false;
        }

    }

    private void SetParrent()
    {
        if (transform.parent == null)
        {
            transform.SetParent(Heroe.transform);
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
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && isGround == false && moveScript.reservTimeJumpPermisison == false && moveScript.isJump == false)
            {
                moveScript.reservTimeJumpPermisison = true;
                rigidbodys.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.Space) && moveScript.isOnPlatform == false && moveScript.isHigher == true 
                && moveScript.reservTimeJumpPermisison == false && moveScript.isJump == true)
            {
                moveScript.reservTimeJumpPermisison = true;
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
                    moveScript.reservTimeJumpPermisison = false;
                    moveScript.isJump = false;
                }
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
        soundSCR = SoundListener.GetComponent<Sounds>();
        moveScript = GetComponentInParent<Moove>();
        raycastDistance = 1.2f;
    }


    void Update()
    {
        RaycastLeftRightChecker();
        SetParrent();
    }
}
