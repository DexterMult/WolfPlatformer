using UnityEngine;

public class JumpUp : MonoBehaviour
{
	private GroundChecker groundChecker;
	private Rigidbody2D rb;
	private float jumpForce;
	public void SetJumpUp()
	{
		groundChecker.SetJump(false);
		groundChecker.SetFall(false);
		groundChecker.SetJumpUp(true);
		GoJumpUp();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

	}
	private void GoJumpUp()
	{

		rb.linearVelocityY = 0;
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

	}
	public void GoJumpUpTramplin(float jumpForceTramplin)
	{
		groundChecker.SetJump(false);
		groundChecker.SetFall(false);
		groundChecker.SetJumpUp(true);
		rb.linearVelocityY = 0;
		rb.AddForce(Vector2.up * jumpForceTramplin, ForceMode2D.Impulse);
	}
	void Start()
	{
		jumpForce = 70f;
		rb = GetComponent<Rigidbody2D>();
		groundChecker = GetComponent<GroundChecker>();
	}
}
