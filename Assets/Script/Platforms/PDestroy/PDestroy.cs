using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PDestroy : MonoBehaviour
{
    private Spawner spawner;
    private Animator animator;
    private Rigidbody2D rb;
    private bool onTriggerPermission;

    private BoxCollider2D boxColliderActor;
    private BoxCollider2D boxColliderPlatform;

    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string MID = "mid";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            if (onTriggerPermission == true)
            {
                boxColliderActor = collision.GetComponent<BoxCollider2D>();
                animator.SetTrigger("CheckActor");
                spawner.localSpawnPoints.Add(transform.localPosition);
                spawner.StartSpawn(MID, spawner.localSpawnPoints[spawner.localSpawnPoints.Count - 1]);
                StartCoroutine(DeletingParent());
                spawner.StartListClear();
                onTriggerPermission = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.parent == null)
        {
            if (collision.transform.position.y< transform.position.y || collision.transform.tag == "Ground0" || collision.transform.tag == "PlatformTag")
            {
                Destroy(gameObject);
            }
        }
    }
    private IEnumerator DeletingParent()
    {
        yield return new WaitForSeconds(1);
        transform.parent = null;
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        boxColliderPlatform = gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(boxColliderPlatform, boxColliderActor);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        onTriggerPermission = true;
        spawner = transform.parent.GetComponent<Spawner>();
    }
}
