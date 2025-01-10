using UnityEngine;

public class StarsController : MonoBehaviour
{
	private SavedSistem savedSistem;
	[SerializeField] private int normalCoinsResult;
	[SerializeField] private float normalTimeResult;
	private float actualGameTime;
	[SerializeField] private int normalHealchResult;
	private int actualHealch;

	private int starsForTime;
	private int starsForCoins;
	private int starsForHealch;

	public int actualCoins;
	public int finalStarsResult;

	public void StartStarsCalculation()
	{
		GetActualCoins();
		CoinsResult();
		GetActualTime();
		TimeResult();
		GetActualHealch();
		HealchResult();
		finalStarsResult = starsForCoins + starsForTime + starsForHealch;
		savedSistem.SetStarsResult(finalStarsResult);
	}
	private void GetActualCoins()
	{
		PieChanger pieChanger = GameObject.Find("Score").GetComponent<PieChanger>();
		if (pieChanger != null)
		{
			actualCoins = pieChanger.pie;
		}
	}
	private void CoinsResult()
	{
		if (actualCoins >= normalCoinsResult)
		{
			starsForCoins = 1;
		}
	}
	private void GetActualTime()
	{
		Timer timer = FindFirstObjectByType<Timer>();
		actualGameTime = timer._timer;
	}
	private void TimeResult()
	{
		if (actualGameTime <= normalTimeResult)
		{
			starsForTime = 1;
		}
	}
	private void GetActualHealch()
	{
		HealthMonitor healch = FindFirstObjectByType<HealthMonitor>();
		if (healch != null)
		{
			
		actualHealch = healch.fullHP;
		}
	}
	private void HealchResult()
	{
		if (actualHealch >= normalHealchResult)
		{
			starsForHealch = 1;
		}
	}
	
	void Start()
	{
		starsForCoins = 0;
		starsForTime = 0;
		starsForHealch = 0;
		finalStarsResult = 0;
		savedSistem = GameObject.FindFirstObjectByType<SavedSistem>();
	}

}
