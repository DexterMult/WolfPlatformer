using System.Collections;
using TMPro;
using UnityEngine;
public class CharacterBubble : MonoBehaviour
{
	private bool onDialog1 = false;
	private bool onDialog2 = false;
	private bool onDialog3 = false;

	private GameObject actor;
	public GameObject actorFather;
	public GameObject actorGrandpa;
	public GameObject actorUncle;

	private TextMeshProUGUI textActor;
	private TextMeshProUGUI textActorFather;
	private TextMeshProUGUI textActorGranpa;
	private TextMeshProUGUI textActorUncle;
	

	public GameObject bubbleActorFather;
	public GameObject bubbleActorGrandpa;
	public GameObject bubbleActorUncle;

	private Animator fatherAnim;
	private Animator granpaAnim;
	private Animator uncleAnim;
	private float offset;

	// позиция бабла отца
	private float offsetFatherX = -5.2f;
	private float offsetFatherY = -2f;
	// позиция бабла деда
	private float offsetGranpaY = 3f;

	// диалог 1
	private string actorPhrase1 = "Привет, пап";
	private string actorFatherPhrase1 = "Привет, сынок";
	// диалог 2	
	private string actorPhrase2 = "Привет, дед";
	private string actorGrandpaPhrase1 = "Привет, внучок";
	// диалог 3	
	private string actorPhrase3 = "Привет, дядя Вульф";
	private string actorUnclePhrase1 = "Привет, племяш";
	void Start()
	{
		DialogHandler.Dialog1 += Dialog1On;
		DialogHandler.Dialog2 += Dialog2On;
		DialogHandler.Dialog3 += Dialog3On;
		offset = 3f;
		textActor = GetComponentInChildren<TextMeshProUGUI>();
		actor = GameObject.Find("Actor");
		gameObject.SetActive(false);
		bubbleActorFather?.SetActive(false);
		bubbleActorGrandpa?.SetActive(false);
		bubbleActorUncle?.SetActive(false);
	}

	//диалог1
	public void Dialog1On()
	{
		if (onDialog1 == false)
		{
			onDialog1 = true;


			gameObject.SetActive(true);
			bubbleActorFather.SetActive(true);

			textActorFather = bubbleActorFather.GetComponentInChildren<TextMeshProUGUI>();
			fatherAnim = actorFather.GetComponent<Animator>();

			fatherAnim.SetBool("OnAction", false);

			textActor.text = actorPhrase1;
			textActorFather.text = actorFatherPhrase1;

			StartCoroutine(DialogDisable());
		}
	}

	private IEnumerator DialogDisable()
	{
		yield return new WaitForSeconds(2);
		fatherAnim.SetBool("OnAction", true);
		onDialog1 = false;
		bubbleActorFather.SetActive(false);
		gameObject.SetActive(false);
	}
	//диалог 2
	private void Dialog2On()
	{
		if (onDialog2 == false)
		{
			NuPogodiRun nuPogodiScr = actorGrandpa.GetComponent<NuPogodiRun>();
			nuPogodiScr.movePermission = true;
			onDialog2 = true;

			gameObject.SetActive(true);
			bubbleActorGrandpa.SetActive(true);

			textActorGranpa = bubbleActorGrandpa.GetComponentInChildren<TextMeshProUGUI>();
			granpaAnim = actorGrandpa.GetComponent<Animator>();

			granpaAnim.SetTrigger("SetMove");

			textActor.text = actorPhrase2;
			textActorGranpa.text = actorGrandpaPhrase1;

			StartCoroutine(DialogDisable2());
		}
	}

	private IEnumerator DialogDisable2()
	{
		yield return new WaitForSeconds(2);
		onDialog2 = false;
		bubbleActorGrandpa.SetActive(false);
		gameObject.SetActive(false);
	}
	
		private void Dialog3On()
	{
		if (onDialog3 == false)
		{
			onDialog2 = true;

			gameObject.SetActive(true);
			bubbleActorUncle.SetActive(true);

			textActorUncle = bubbleActorUncle.GetComponentInChildren<TextMeshProUGUI>();
			uncleAnim = actorUncle.GetComponent<Animator>();

			uncleAnim.SetTrigger("SetAnim");

			textActor.text = actorPhrase3;
			textActorUncle.text = actorUnclePhrase1;

			StartCoroutine(DialogDisable3());
		}
	}
		private IEnumerator DialogDisable3()
	{
		yield return new WaitForSeconds(2);
		onDialog3 = false;
		bubbleActorUncle.SetActive(false);
		gameObject.SetActive(false);
	}
	private void OnDestroy()
	{
		DialogHandler.Dialog1 -= Dialog1On;
		DialogHandler.Dialog2 -= Dialog2On;
		DialogHandler.Dialog3 -= Dialog3On;
		
	}
	void Update()
	{
		if (gameObject.activeSelf == true)
		{
			transform.position = new Vector2(actor.transform.position.x, actor.transform.position.y + offset);
			if (bubbleActorFather != null && actorFather != null)
			{
				bubbleActorFather.transform.position = new Vector2(actorFather.transform.position.x + offsetFatherX, actorFather.transform.position.y + offsetFatherY);
			}
			if (bubbleActorGrandpa != null && actorGrandpa != null)
			{
				bubbleActorGrandpa.transform.position = new Vector2(actorGrandpa.transform.position.x, actorGrandpa.transform.position.y + offsetGranpaY);
			}
		}
	}
}