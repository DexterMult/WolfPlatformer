using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class FrogDestroy : MonoBehaviour
{
	[SerializeField]
	private GameObject thisObj;
	private GameObject particleObj;
	[SerializeField] private GameObject ParticleDeath;
	private bool damagePermission = true;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("ActorTag"))
		{
			if (damagePermission == true)
			{
				damagePermission = false;
				JumpUp jump = collision.GetComponent<JumpUp>();
				jump.SetJumpUp();
				SoundEvents.SetActionHit();
				particleObj = Instantiate(ParticleDeath, collision.transform.position, Quaternion.identity);
				StartCoroutine(DestroyPrefab());
				Destroy(thisObj);
			}
		}
	}
	private IEnumerator DestroyPrefab()
	{
		yield return new WaitForSeconds(3);
		Destroy(particleObj);
	}
}
