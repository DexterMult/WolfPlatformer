using UnityEngine;
using System.Collections;

public class JumpDown : MonoBehaviour
{
    private Collider2D collider2;
    private GroundChecker groundChecker;
    private Collider2D colliderOneWeyPlatform;

    private IEnumerator SetJumpDown()
    {
        if (Input.GetButtonDown("JumpDown") && groundChecker.isPOneWey == true)
        {
            groundChecker.SetisPOneWey(false);
            groundChecker.SetFall(true);
            Physics2D.IgnoreCollision(collider2, colliderOneWeyPlatform);
            yield return new WaitForSeconds(0.3f);
            Physics2D.IgnoreCollision(collider2, colliderOneWeyPlatform, false);
            colliderOneWeyPlatform = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("POneWayTag"))
        {
            colliderOneWeyPlatform = collision.collider;
        }
    }
    void Start()
    {
        groundChecker = GetComponent<GroundChecker>();
        collider2 = GetComponent<Collider2D>();
    }

    void Update()
    {
        StartCoroutine(SetJumpDown());
    }
}
