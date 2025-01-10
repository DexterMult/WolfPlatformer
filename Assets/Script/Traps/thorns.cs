using UnityEngine;

public class thorns : MonoBehaviour
{
    private HealthMonitor healthMonitor;
    private GroundChecker groundChecker;
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            groundChecker = collision.GetComponent<GroundChecker>();
            if (groundChecker.isGhost == false && groundChecker.isDeath == false)
            {
                groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); //определяет с какой стороны Enemy от героя
                groundChecker.SetIsDamage(true);
                groundChecker.SetIsGhost(true);
                groundChecker.SetIsKickFall(true);
                healthMonitor.SetDamage(damage);
            }
        }
    }
    void Start()
    {
        healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
    }
}
