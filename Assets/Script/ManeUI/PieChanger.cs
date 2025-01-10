using UnityEngine;
using TMPro;
public class PieChanger : MonoBehaviour
{
	private GameObject[] allBun;
	private BonusesChecker bonusesChecker;
	public int pie;

	private TextMeshProUGUI scoreTMP;

	private void SetScore()
	{
		pie = pie + 1;
		scoreTMP.text = pie.ToString();
	}
	void Start()
	{
		scoreTMP = GetComponent<TextMeshProUGUI>();
		pie = 0;

		allBun = GameObject.FindGameObjectsWithTag("BunTag");
		foreach (GameObject bun in allBun)
		{
			bonusesChecker = bun.GetComponent<BonusesChecker>();
			bonusesChecker.EatPieEvent += SetScore;
		}
	}
	private void OnDestroy()
	{
		if(bonusesChecker != null){
			bonusesChecker.EatPieEvent -= SetScore;
		}
	}
}
