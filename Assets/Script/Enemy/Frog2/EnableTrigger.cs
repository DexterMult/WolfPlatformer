using UnityEngine;

public class EnableTrigger : MonoBehaviour
{
	private HealthMonitor healthMonitor;
	private BoxCollider2D box;
	private int damage;
	private GroundChecker groundChecker;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ActorTag"))
		{
			groundChecker = collision.GetComponent<GroundChecker>();
			if (groundChecker.isGhost == false && groundChecker.isDeath == false)
			{
				groundChecker.SetIsDamageHorizontalSide(collision.transform.position, GetComponentInParent<Transform>().position); //���������� � ����� ������� Enemy �� �����
				groundChecker.SetIsDamage(true);
				groundChecker.SetIsGhost(true);
				groundChecker.SetIsKickFall(true);
				healthMonitor.SetDamage(damage);
			}
		}
	}

	void Start()
	{
		box = GetComponent<BoxCollider2D>();
		box.enabled = false;
		damage = 1;
		healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
	}

	private void BoxEnable()
	{
		box.enabled = true;
	}
	private void BoxDisable()
	{
		box.enabled = false;
	}

}
