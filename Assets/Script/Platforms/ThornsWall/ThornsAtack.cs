using System.Collections;
using UnityEngine;

public class ThornsAtack : MonoBehaviour
{
    private float firstDuration;
    private float standartDuration;
    private HealthMonitor healthMonitor;
    private GroundChecker groundChecker;
    private Animator animator;
    private int damage = 1;
    private BoxCollider2D[] boxColliders;

    private bool isThornsUp;
    void Start()
    {
        isThornsUp = false;
        firstDuration = 1f;
        standartDuration = 2f;
        animator = GetComponent<Animator>();
        boxColliders = GetComponents<BoxCollider2D>();
        healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();

        StartCoroutine(StartThorns());
    }

    private IEnumerator StartThorns()
    {
        yield return new WaitForSeconds(firstDuration);
        if (isThornsUp == true) 
        {
            SetThornsDown();
        } 
        else if (isThornsUp == false) 
        {
            SetThornsUp();
        }
        firstDuration = standartDuration;
        StartCoroutine(StartThorns());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            groundChecker = collision.GetComponent<GroundChecker>();
            if (groundChecker.isGhost == false && groundChecker.isDeath == false)
            {
                groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); 
                groundChecker.SetIsDamage(true);
                groundChecker.SetIsGhost(true);
                groundChecker.SetIsKickFall(true);
                healthMonitor.SetDamage(damage);
            }
        }
    }
    private void SetThornsUp()
    {
        animator.SetTrigger("isThornsUp");
        foreach (var boxCollider in boxColliders)
        {
            boxCollider.enabled = true;
        }
        isThornsUp = true;
    }    
    private void SetThornsDown()
    {
        animator.SetTrigger("isThornsDown");
        foreach (var boxCollider in boxColliders)
        {
            boxCollider.enabled = false;
        }
        isThornsUp = false;
    }
}
