using UnityEngine;
using UnityEngine.Tilemaps;
public class ShowHideTileMap : MonoBehaviour
{
	[SerializeField] private TilemapRenderer tilemapRenderer1;
	[SerializeField] private BoxCollider2D colliderTrigger1;
	private bool isEntred = false;

	void ToggleRenderer()
	{
		if (tilemapRenderer1 != null)
		{
			tilemapRenderer1.enabled = !tilemapRenderer1.enabled;
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.tag == "ActorTag" && isEntred == false)
		{
			isEntred = true;
			ToggleRenderer();
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.transform.tag == "ActorTag" && isEntred == true)
		{
			isEntred = false;
			ToggleRenderer();
		}
	}
}
