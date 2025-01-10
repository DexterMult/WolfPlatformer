using System;
using System.Collections;
using UnityEngine;

public class IeaveTrigger : MonoBehaviour
{
	private GameObject particle;
	[SerializeField]
	private GameObject objectToSpawn;
	private bool createPermission = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.transform.tag == "ActorTag" && createPermission == true)
		{
			particle = Instantiate(objectToSpawn, other.transform.position, Quaternion.identity);
			createPermission = false;
			SoundEvents.SetActionLeaves();
			StartCoroutine(DestroyPrefab());
		}
	}
	private IEnumerator DestroyPrefab()
	{
		yield return new WaitForSeconds(3);
		Destroy(particle);
		createPermission = true;
	}
}
