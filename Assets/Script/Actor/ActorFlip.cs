using UnityEngine;

public class ActorFlip : MonoBehaviour
{
	private GroundChecker groundChecker;
	public void FlipBody()
	{
		if (groundChecker.isDeath == false)
		{
			Vector3 scale = transform.localScale;
			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
			{
				return;
			}
			else if (Input.GetKey(KeyCode.A) && Input.GetKeyUp(KeyCode.D) && scale.x > 0)
			{
				scale.x *= -1;
			}
			else if (Input.GetKey(KeyCode.D) && Input.GetKeyUp(KeyCode.A) && scale.x < 0)
			{
				scale.x *= -1;
			}
			else if (Input.GetKeyDown(KeyCode.A) && scale.x > 0)
			{
				scale.x *= -1;
			}
			else if (Input.GetKeyDown(KeyCode.D) && scale.x < 0)
			{
				scale.x *= -1;
			}
			transform.localScale = scale;
		}
	}
	private void Update()
	{
		FlipBody();
	}
	private void Start()
	{
		groundChecker = GetComponent<GroundChecker>();
	}
}
