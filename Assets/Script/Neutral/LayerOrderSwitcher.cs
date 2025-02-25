using UnityEngine;

public class LayerOrderSwitcher : MonoBehaviour
{
	// Публичные переменные
	public int newOrderInLayer; // Новый OrderInLayer, который нужно установить
	public int standartOrderInLayer;
	private bool isOrderChanged = false; // Флаг для отслеживания, был ли OrderInLayer изменен
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "ActorTag" && (transform.position.x > other.transform.position.x))
		{
			if (isOrderChanged == true)
			{
				Debug.Log("48");
				isOrderChanged = false;
				// Получаем компонент SpriteRenderer у объекта, который вошел в триггер
				SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
				if (spriteRenderer != null)
				{
					// Устанавливаем новый OrderInLayer
					spriteRenderer.sortingOrder = standartOrderInLayer;
				}
			}
		}
		if (other.tag == "ActorTag" && (transform.position.x < other.transform.position.x))
		{
			if (isOrderChanged == false)
			{
				Debug.Log("70");
				isOrderChanged = true;
				// Получаем компонент SpriteRenderer у объекта, который вошел в триггер
				SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
				if (spriteRenderer != null)
				{
					// Устанавливаем новый OrderInLayer
					spriteRenderer.sortingOrder = newOrderInLayer;
				}
			}
		}
	}
	void Start()
	{
		isOrderChanged = false;
	}


	// private void OnTriggerEnter2D(Collider2D other)
	// {
	// 	// Проверяем, что объект, вошедший в триггер, имеет тег "ActorTag"
	// 	if (other.CompareTag("ActorTag") && flag == true)
	// 	{
	// 		flag = false;
	// 		// Получаем компонент SpriteRenderer у объекта, который вошел в триггер
	// 		SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();

	// 		if (spriteRenderer != null)
	// 		{
	// 			if (!isOrderChanged)
	// 			{
	// 				// Сохраняем текущий OrderInLayer
	// 				savedOrderInLayer = spriteRenderer.sortingOrder;

	// 				// Устанавливаем новый OrderInLayer
	// 				spriteRenderer.sortingOrder = newOrderInLayer;

	// 				// Устанавливаем флаг, что OrderInLayer был изменен
	// 				isOrderChanged = true;
	// 			}
	// 			else
	// 			{
	// 				// Возвращаем сохраненный OrderInLayer
	// 				spriteRenderer.sortingOrder = savedOrderInLayer;

	// 				// Сбрасываем флаг
	// 				isOrderChanged = false;
	// 			}
	// 		}
	// 	}
	// }
	// private void OnTriggerExit2D(Collider2D other)
	// {
	// 	if (other.CompareTag("ActorTag") && flag == false)
	// 	{
	// 		flag = true;
	// 	}

	
	// }
}