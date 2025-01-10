using UnityEngine;

public class DeathRaven : MonoBehaviour
{
	[SerializeField] private GameObject thisObj;
	[SerializeField] private GameObject ParticleDeath;
	private bool damagePermission = true;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ActorTag"))
		{
			if (damagePermission == true)
			{
				JumpUp jump = collision.GetComponent<JumpUp>();
				jump.SetJumpUp();
				SoundEvents.SetActionHit();
				damagePermission = false;
				Instantiate(ParticleDeath, collision.transform.position, Quaternion.identity);
				Destroy(thisObj);
			}
		}
	}
}
