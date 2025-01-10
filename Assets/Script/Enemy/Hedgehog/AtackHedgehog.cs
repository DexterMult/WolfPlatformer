using UnityEngine;

public class AtackHedgehog : MonoBehaviour
{
	private HealthMonitor healthMonitor;
	private int damage;
	private GroundChecker groundChecker;

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

	void Start()
	{
		damage = 1;
		healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
	}
}
