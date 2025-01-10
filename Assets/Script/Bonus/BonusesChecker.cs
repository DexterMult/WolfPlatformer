using UnityEngine;
using System;
public class BonusesChecker : MonoBehaviour
{
	public event Action EatPieEvent;
	private bool trigerPermission = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ActorTag") && trigerPermission == true) 
		{
			trigerPermission = false;
			EatPieEvent?.Invoke();
			SoundEvents.SetActionEat();
			Destroy(gameObject);
		}
	}
}
