using UnityEngine;

public class NuPogodiRun : MonoBehaviour
{
	private float speed = 1;
	public bool movePermission;

	private void MoveUp()
	{
		if (movePermission == true)
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
	}

	private void Start()
	{
		movePermission = false;
	}
	void Update()
	{
		MoveUp();
	}
}
