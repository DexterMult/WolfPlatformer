using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
	private GroundChecker groundChecker;
	private PausedGame pausedGame;
	[SerializeField] private GameObject loseGamePanel;
	public int fullHP;

	public void SetDamage(int damage)
	{
		if (fullHP <= 0)
			return;
		fullHP = fullHP - damage;
	}
	void Start()
	{
		groundChecker = GameObject.Find("Actor").GetComponent<GroundChecker>();
		pausedGame = GameObject.Find("PausedObj").GetComponent<PausedGame>();
		fullHP = 3;
	}

	private void SetIsDeath()
	{
		if (fullHP <= 0)
		{
			EnableLosePanel();
			pausedGame.PauseGame();
			groundChecker.isDeath = true;
		}
		else { groundChecker.isDeath = false; }
	}

	private void EnableLosePanel()
	{
		loseGamePanel.SetActive(true);
	}
	
	private void Update()
	{
		SetIsDeath();
	}
}
