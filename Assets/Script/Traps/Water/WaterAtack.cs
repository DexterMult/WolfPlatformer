using UnityEngine;

public class WaterAtack : MonoBehaviour
{
	private HealthMonitor healthMonitor;
	private int damage;
	private GroundChecker groundChecker;
	private bool atackPermission;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ActorTag"))
		{
			groundChecker = other.GetComponent<GroundChecker>();
			if (groundChecker.isGhost == false && groundChecker.isDeath == false && atackPermission == true)
			{
				groundChecker.SetIsDamageHorizontalSide(other.transform.position, GetComponentInParent<Transform>().position);
				groundChecker.SetIsDamage(true);
				groundChecker.SetIsGhost(true);
				groundChecker.SetIsKickFall(true);
				healthMonitor.SetDamage(damage);
				atackPermission = false;
			}
		}
	}
	private void Start()
	{
		atackPermission = true;
		damage = 3;
		healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
	}
}
