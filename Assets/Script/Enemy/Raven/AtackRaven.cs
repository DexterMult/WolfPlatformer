using System.Collections;
using UnityEngine;

public class AtackRaven : MonoBehaviour
{
    private HealthMonitor healthMonitor;
    private int damage;
    private GroundChecker groundChecker;

    private float atackDelay;
    private bool atackPermission;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            groundChecker = collision.GetComponent<GroundChecker>();
            if (groundChecker.isGhost == false && groundChecker.isDeath == false && atackPermission == true)
            {
                groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); //���������� � ����� ������� Enemy �� �����
                groundChecker.SetIsDamage(true);
                groundChecker.SetIsGhost(true);
                groundChecker.SetIsKickFall(true);
                healthMonitor.SetDamage(damage);
                atackPermission = false;
                StartCoroutine(SetAtackPermission());
            }
        }
    }

    private IEnumerator SetAtackPermission()
    {
        yield return new WaitForSeconds(atackDelay);
        atackPermission = true;
    }

    void Start()
    {
        atackDelay = 3f;
        atackPermission = true;
        damage = 1;
        healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
    }
}
