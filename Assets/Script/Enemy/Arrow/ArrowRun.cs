using System.Collections;
using UnityEngine;

public class ArrowRun : MonoBehaviour
{
    private Transform transParent;
    private float maxDistance;
    private float speed;
    private float unParrentDelay;
    private Vector2 startPosition;
    private HealthMonitor healthMonitor;
    private int damage = 1;

    private GroundChecker groundChecker;

    private IEnumerator UnParrent()
    {
        yield return new WaitForSeconds(unParrentDelay);
        transform.parent = null;
        Collider2D collider2 = GetComponent<Collider2D>();
        collider2.enabled = true;
    }

    private void Moov()
    {
        if (transform.parent == null)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public float CalculateDistance(Vector2 pointA, Vector2 pointB)
    {
        return Vector2.Distance(pointA, pointB);
    }

    private void SetDestroy()
    {
        if (maxDistance <= CalculateDistance(startPosition, transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Untagged" && (collision.tag != "ActorTag"))
        {

            Destroy(gameObject);
        }
        else if (collision.tag == "ActorTag")
        {
            groundChecker = collision.GetComponent<GroundChecker>();

            if (groundChecker.isGhost == false && groundChecker.isDeath == false)
            {
                groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); //���������� � ����� ������� Enemy �� �����
                groundChecker.SetIsDamage(true);
                groundChecker.SetIsGhost(true);
                groundChecker.SetIsKickFall(true);
                healthMonitor.SetDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
        maxDistance = 20f;
        unParrentDelay = 1f;
        speed = 8f;
        transParent = GetComponentInParent<Transform>();
        startPosition = transParent.position;
        StartCoroutine(UnParrent());

    }
    private void Update()
    {
        Moov();
        SetDestroy();
    }
}
