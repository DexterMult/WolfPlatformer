using UnityEngine;

public class ThornsDestroy : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage = 1;
    private HealthMonitor healthMonitor;
    private GroundChecker groundChecker;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            if (collision.collider.tag != "ActorTag")
            {
                Destroy(gameObject);
            }
            if (collision.collider.CompareTag("ActorTag"))
            {
                groundChecker = collision.gameObject.GetComponent<GroundChecker>();
                if (groundChecker.isGhost == false && groundChecker.isDeath == false)
                {
                    groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); //���������� � ����� ������� Enemy �� �����
                    groundChecker.SetIsDamage(true);
                    groundChecker.SetIsGhost(true);
                    groundChecker.SetIsKickFall(true);
                }
                healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
                healthMonitor.SetDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
