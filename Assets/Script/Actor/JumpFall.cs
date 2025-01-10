using UnityEngine;

public class JumpFall : MonoBehaviour
{
	private bool canFirstJump;
	private bool canLastJump;
	private float jumpForce;

	private GroundChecker groundChecker;
	private Rigidbody2D rigidbody2;

	[SerializeField]
	private ParticleSystem dust;
	private void SetJumpFall()
	{
		if (groundChecker.isFall == true && groundChecker.isDamage == false)
		{
			if (Input.GetButtonDown("Jump"))
			{
				if (canFirstJump == true)
				{
					SoundEvents.SetActionJump();
					dust.Play();
					rigidbody2.linearVelocityY = 0f;
					rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					canFirstJump = false;
					canLastJump = true;
				}
				else if (canLastJump == true)
				{
					SoundEvents.SetActionJump();
					dust.Play();
					rigidbody2.linearVelocityY = 0f;
					rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
					canLastJump = false;
				}
			}
		}
	}

	private void JumpPermissionReload()
	{
		if (groundChecker.isFall == false)
		{
			canFirstJump = true;
		}
	}
   
	void Start()
	{
		groundChecker = GetComponent<GroundChecker>();  
		rigidbody2 = GetComponent<Rigidbody2D>();
		canFirstJump = true;
		canLastJump = false;
		jumpForce = 100f;
	}

	void Update()
	{
		SetJumpFall();
		JumpPermissionReload();
	}
}
