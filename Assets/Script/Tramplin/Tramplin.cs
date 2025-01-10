using UnityEngine;

public class Tramplin : MonoBehaviour
{
	[SerializeField]
	private float jumpForceTramplin;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "ActorTag")
		{
			GroundChecker groundChecker = collision.GetComponent<GroundChecker>();
			JumpUp jump = collision.GetComponent<JumpUp>();
			jump.GoJumpUpTramplin(jumpForceTramplin);
			SoundEvents.SetActionTramplinJump();
		}
	}
}
