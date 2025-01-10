using Unity.VisualScripting;
using UnityEngine;

public class StarsSound : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		
		if (other.transform.tag == "Ground0" || other.transform.tag == "PlatformTag" || other.transform.tag == "POneWeyTag")
		{
			SoundEvents.SetActionStarsSparkling();
		}
	}
}
