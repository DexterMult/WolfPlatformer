using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class EndGameTrigger : MonoBehaviour
{
	public PausedGame PausedGame;
	private GameObject Actor;
	public GameObject EndGamePanel;
	public SavedSistem SavedSistem;
	public PieChanger pieChanger; //получаем результат пирожков
	public TextMeshProUGUI pieResultTMP;
	public PieChanger bonusesChecker;

	public Image noActiveStar1;
	public Image noActiveStar2;
	public Image noActiveStar3;
	public Image ActiveStar1;
	public Image ActiveStar2;
	public Image ActiveStar3;

	private int coinsFinalResult;

	private void ShowPieResult()
	{
		pieResultTMP.text = pieChanger.pie.ToString();
	}
	private void GainCoin()
	{
		coinsFinalResult = bonusesChecker.pie;
	}

	private int finalStarsResult; //Итоговое кол-во пирожков

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "ActorTag")
		{
			GainCoin();
			SoundEvents.SetActionWin();
			EndGamePanel.SetActive(true);
			ShowPieResult();
			StarsDemonstration();
			SavedSistem.SetCoinsResult(coinsFinalResult);
			SavedSistem.SavedAllGame();
			PausedGame.PauseGame();

		}
	}

	// Поворот красной шапочки к ГГ
	private void RedHudRotation()
	{
		if (Actor != null)
		{
			Vector2 ActorPosition;
			Vector2 RedHudPosition;

			ActorPosition = new Vector2(Actor.transform.position.x, Actor.transform.position.y);
			RedHudPosition = new Vector2(transform.position.x, transform.position.y);

			if (ActorPosition.x < RedHudPosition.x)
			{
				transform.localScale = new Vector2(1, 1);
			}
			else if (ActorPosition.x > RedHudPosition.x)
			{
				transform.localScale = new Vector2(-1, 1);
			}
		}
		else { return; }
	}

	private void GetStarsResult()
	{
		StarsController starsController = FindFirstObjectByType<StarsController>();
		starsController.StartStarsCalculation();
		finalStarsResult = starsController.finalStarsResult;
	}
	//Расчет звезд
	private void StarsDemonstration()
	{
		GetStarsResult();

		if (finalStarsResult == 0)
		{
			noActiveStar1.gameObject.SetActive(true);
			noActiveStar2.gameObject.SetActive(true);
			noActiveStar3.gameObject.SetActive(true);

			ActiveStar1.gameObject.SetActive(false);
			ActiveStar2.gameObject.SetActive(false);
			ActiveStar3.gameObject.SetActive(false);
		}

		else if (finalStarsResult == 1)
		{
			noActiveStar1.gameObject.SetActive(false);
			noActiveStar2.gameObject.SetActive(true);
			noActiveStar3.gameObject.SetActive(true);

			ActiveStar1.gameObject.SetActive(true);
			ActiveStar2.gameObject.SetActive(false);
			ActiveStar3.gameObject.SetActive(false);
		}

		else if (finalStarsResult == 2)
		{
			noActiveStar1.gameObject.SetActive(false);
			noActiveStar2.gameObject.SetActive(false);
			noActiveStar3.gameObject.SetActive(true);

			ActiveStar1.gameObject.SetActive(true);
			ActiveStar2.gameObject.SetActive(true);
			ActiveStar3.gameObject.SetActive(false);
		}
		else if (finalStarsResult == 3)
		{
			noActiveStar1.gameObject.SetActive(false);
			noActiveStar2.gameObject.SetActive(false);
			noActiveStar3.gameObject.SetActive(false);

			ActiveStar1.gameObject.SetActive(true);
			ActiveStar2.gameObject.SetActive(true);
			ActiveStar3.gameObject.SetActive(true);
		}
	}
	// Деактивация звезд на старте
	private void StarsOnStartNoActive()
	{
		noActiveStar1.gameObject.SetActive(false);
		noActiveStar2.gameObject.SetActive(false);
		noActiveStar3.gameObject.SetActive(false);

		ActiveStar1.gameObject.SetActive(false);
		ActiveStar2.gameObject.SetActive(false);
		ActiveStar3.gameObject.SetActive(false);
	}

	private void Start()
	{
		StarsOnStartNoActive();
		Actor = GameObject.Find("Actor");
		coinsFinalResult = 0;
		bonusesChecker = GameObject.FindAnyObjectByType<PieChanger>();
	}
	private void OnEnable()
	{
		PausedGame.ResumeGame();
	}
	private void Update()
	{
		RedHudRotation();
	}
}
