using UnityEngine;

public class WaterSplash : MonoBehaviour
{
	private GroundChecker groundChecker;
	[SerializeField] private ParticleSystem miniSplash;
	[SerializeField] private ParticleSystem bigSplash;
	[SerializeField] private Transform splashSpawnPosition;
	private bool bigSplashSpawnPermission;
	private static bool isExitingGame = false;
		void OnApplicationQuit()
	{
		isExitingGame = true;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "WaterTag" && bigSplashSpawnPermission == true)
		{
			SoundEvents.SetActionBigEnteriWaterSplash();
			Instantiate(bigSplash, splashSpawnPosition.position, bigSplash.transform.rotation);
			bigSplashSpawnPermission = false;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "WaterTag" && bigSplashSpawnPermission == false && isExitingGame == false)
		{
			SoundEvents.SetActionBigExitWaterSplash();
			Instantiate(bigSplash, splashSpawnPosition.position, bigSplash.transform.rotation);
			bigSplashSpawnPermission = true;
		}
	}

	public void SpawnMiniSplawh()
	{
		if (groundChecker.isWater == true)
		{
			SoundEvents.SetActionMiniWaterSplash();
			Instantiate(miniSplash, splashSpawnPosition.position, miniSplash.transform.rotation);
		}
	}

	void Start()
	{
		isExitingGame = false;
		groundChecker = GetComponent<GroundChecker>();
		bigSplashSpawnPermission = true;
	}
}
