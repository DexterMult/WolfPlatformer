using UnityEngine;

public class SavedSistem : MonoBehaviour
{
	private LVLChoice LVLChoice;
	private StarsController starsController;
	private Timer Timer;
	private int lvlNum;
	private float allTimeResult;
	private float timeMinutsResult;
	private float timeSecundsResult;
	private int coinsResult;
	private int starsResult;

	public void SavedComplitLVL()
	{
		PlayerPrefs.SetInt("ComplitLVL"+lvlNum, 1);
	}

	public void SetStarsResult(int starsResult)
	{
		this.starsResult = starsResult;
	}
	public void SetCoinsResult(int coinsResult)
	{
		this.coinsResult = coinsResult;
	}

	private void SavedCoins()
	{
		if (coinsResult >= PlayerPrefs.GetInt("coinsResult" + lvlNum, 0))
		{
			PlayerPrefs.SetInt("coinsResult" + lvlNum, coinsResult);
		}
	}

	private void SavedTime()
	{
		allTimeResult = Timer._timer;
		timeMinutsResult = Timer._minuts;
		timeSecundsResult = Timer._secund;
		if ((allTimeResult <= PlayerPrefs.GetFloat("allTimeResult" + lvlNum))|| (PlayerPrefs.GetFloat("allTimeResult") == 0))
		{
			PlayerPrefs.SetFloat("allTimeResult" + lvlNum, allTimeResult);
			PlayerPrefs.SetFloat("timeMinutsResult" + lvlNum, timeMinutsResult);
			PlayerPrefs.SetFloat("timeSecundsResult" + lvlNum, timeSecundsResult);
		}
	}

	private void SavedStars()
	{
		starsResult = starsController.finalStarsResult;
		if (starsResult >= PlayerPrefs.GetInt("starsResult" + lvlNum, 0))
		{
			PlayerPrefs.SetInt("starsResult" + lvlNum, starsResult);
		}
	}

	public void SavedAllGame()
	{
		SavedCoins();
		SavedTime();
		SavedStars();
	}


	private void Start()
	{
		LVLChoice = GameObject.FindFirstObjectByType<LVLChoice>();
		lvlNum = LVLChoice.sceneIndex;
		starsController = GameObject.FindFirstObjectByType<StarsController>();
		Timer = GameObject.FindFirstObjectByType<Timer>();
	}
}
