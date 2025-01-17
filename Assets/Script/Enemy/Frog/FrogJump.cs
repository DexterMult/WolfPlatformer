using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FrogJump : MonoBehaviour
{
	[Tooltip("Скорость по горизонтали")]
	public float speedX = 5f;
	[Tooltip("Скорость по вертикали")]
	public float raycastDistance = 5f; // Дистанция, на которую будет проверяться наличие объекта с тегом Ground0
	public LayerMask groundLayer; // Слой, на котором находятся объекты с тегом Ground0
	public float speedY = 5f;
	private Vector2 jumpDirection;
	private bool isGround = false;
	private Animator animator;
	[SerializeField] private float startJumpDelay = 0;

	private Rigidbody2D rb;

	void Start()
	{

		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		if (rb == null)
		{
			Debug.LogError("Rigidbody2D не найден на объекте " + gameObject.name + ". Скрипт не будет работать!");
			enabled = false; // Отключаем скрипт, чтобы не было ошибок.
			return;
		}
	}
	void Update()
	{
		if (isGround == true)
		{
			rb.linearVelocityX = 0f;
		}
		else if (isGround == false && rb.linearVelocityY < 0)
		{
			animator.SetInteger("Jump", -1);
		}
	}
	private void FlipFrog()
	{
		Vector3 scale = transform.localScale;

		scale.x *= -1f;
		transform.localScale = scale;
	}
	public void SetDirection()
	{
		jumpDirection = new Vector2(speedX, speedY);
	}
	private void SetSpeed()
	{
		if (transform.localScale.x < 0) // Если объект повернут влево (масштаб отрицательный)
			speedX *= -1;
		else if (transform.localScale.x > 0)
		{
			speedX = Mathf.Abs(speedX);
		}
	}
	private void Jump()
	{
		rb.linearVelocity = jumpDirection;
		isGround = false;
		animator.SetInteger("Jump", 1);
	}
	private IEnumerator JumpDelay()
	{
		yield return new WaitForSeconds(startJumpDelay);
		Jump();
		startJumpDelay = 0;
	}
	private void MakeAllAction()
	{
		SetSpeed();
		SetDirection();
		StartCoroutine(JumpDelay());
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "Ground0" || other.transform.tag == "ActorTag")
		{
			isGround = true;
			animator.SetInteger("Jump", 0);
		}
	}
	

}