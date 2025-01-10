using UnityEngine;
using System.Collections;
public class Run : MonoBehaviour
{
	private Rigidbody2D rigidbody2;
	private float speed;
	private GroundChecker groundChecker;
	private void GoRun()
	{
		if (groundChecker.isDamage == false && groundChecker.isDeath == false)
		{
			if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
			{
				rigidbody2.linearVelocityX = speed * Input.GetAxis("Horizontal");
			}

			if (!Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
			{
				rigidbody2.linearVelocityX = speed * Input.GetAxis("Horizontal");
			}

			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
			{
				rigidbody2.linearVelocityX = 0;
			}

		}
	}
	private void SetWalkSound()
	{
		SoundEvents.SetActionWalk();
	}

	void Start()
	{
		groundChecker = GetComponent<GroundChecker>();
		rigidbody2 = GetComponent<Rigidbody2D>();
		speed = 10;
	}

	void Update()
	{
		GoRun();
	}
}
