using UnityEngine;
using System.Collections;

public class DestroyKillEffect : MonoBehaviour
{
	private IEnumerator DestroyPrefab()
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
	private void Start()
	{
		StartCoroutine(DestroyPrefab());
	}
}
