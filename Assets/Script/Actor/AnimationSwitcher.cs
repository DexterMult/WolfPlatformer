using UnityEngine;

public class AnimationSwitcher : MonoBehaviour
{
	private GroundChecker groundChecker;
	private Animator animator;
	private Rigidbody2D rb;
	void Start()
	{
		animator = GetComponent<Animator>();
		groundChecker = GetComponent<GroundChecker>();
		rb = GetComponent<Rigidbody2D>();
	}
	private void UpOrDownFliChecker()
	{
		if (rb.linearVelocityY > 0)
		{
			animator.SetInteger("Jump", 1);
		}
		else if (rb.linearVelocityY <= 0)
		{
			animator.SetInteger("Jump", -1);
		}
	}
	void Update()
	{
		UpOrDownFliChecker();

		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
		{
			animator.SetInteger("Run", -1);
		}
		else if ((Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S)))
		{
			animator.SetInteger("Run", 1);
		}
		else if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
		{
			animator.SetInteger("Run", -1);
		}
		else if (!Input.GetButton("Horizontal"))
		{
			animator.SetInteger("Run", -1);
		}



		if (groundChecker.isGround || groundChecker.isPStandart || groundChecker.isPOneWey)
		{
			animator.SetInteger("IsGround", 1);
			animator.SetInteger("Jump", 0);
		}
		else if (groundChecker.isGround == false && groundChecker.isPStandart == false && groundChecker.isPOneWey == false)
		{
			animator.SetInteger("IsGround", -1);
		}

		if (groundChecker.isDeath == true)
		{
			animator.SetInteger("isDeath", 1);
			animator.SetInteger("Run", 0);
			animator.SetInteger("IsGround", 0);
			animator.SetInteger("Jump", 0);
		}
		else if (groundChecker.isDeath == false)
		{

			animator.SetInteger("isDeath", -1);
		}
	}
}
