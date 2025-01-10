using UnityEngine;

public class Jumping : MonoBehaviour
{
	private Rigidbody2D rigidbody2;
	private float jumpForce;
	private GroundChecker groundChecker;
	private bool canDoubleJump;
	public ParticleSystem dust;
	private void SetJumping()
	{
		if (Input.GetButtonDown("Jump"))
		{
			if (groundChecker.isDeath == false)
			{
				if ((groundChecker.isGround == true || groundChecker.isPOneWey == true || groundChecker.isPStandart == true || groundChecker.isJumpUP == true) && groundChecker.isDamage == false)
				{
					SoundEvents.SetActionJump();
					dust.Play();
					rigidbody2.linearVelocityY = 0f;
					rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					groundChecker.SetFall(false);
					groundChecker.SetJumpUp(false);
					groundChecker.SetJump(true);
					groundChecker.SetisPOneWey(false);
					canDoubleJump = true;
				}
				else if (canDoubleJump)
				{
					SoundEvents.SetActionJump();
					dust.Play();
					rigidbody2.linearVelocityY = 0f;
					rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					groundChecker.SetFall(false);
					groundChecker.SetJump(true);
					canDoubleJump = false; 
				}
			}
		}
	}
	void Start()
	{
		canDoubleJump = false;
		groundChecker = GetComponent<GroundChecker>();
		rigidbody2 = GetComponent<Rigidbody2D>();
		jumpForce = 100f;
	}

	void Update()
	{
		SetJumping();
	}
}
