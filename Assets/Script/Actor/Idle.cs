using UnityEngine;

public class Idle : MonoBehaviour
{
	private GroundChecker groundChecker;
	private float stopSpeed;
	private Rigidbody2D rigidbody2;
	private void SetIdle()
	{
		if ((!Input.anyKey || Input.GetKey(KeyCode.S)) && groundChecker.isDamage == false && groundChecker.isKickFall == false)
		{
			rigidbody2.linearVelocityX = stopSpeed;
		}
	}
	void Start()
	{
		rigidbody2 = GetComponent<Rigidbody2D>();
		stopSpeed = 0f;
		groundChecker = GetComponent<GroundChecker>();
	}

	void Update()
	{
		SetIdle();
	}
}
