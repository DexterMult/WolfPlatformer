using UnityEngine;

public class LayerOrderSwitcher : MonoBehaviour
{
	// Публичные переменные
	public int newOrderInLayer; // Новый OrderInLayer, который нужно установить

	private int savedOrderInLayer; // Переменная для сохранения текущего OrderInLayer
	private bool isOrderChanged = false; // Флаг для отслеживания, был ли OrderInLayer изменен
	private bool flag = true;
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Проверяем, что объект, вошедший в триггер, имеет тег "ActorTag"
		if (other.CompareTag("ActorTag") && flag == true)
		{
			flag = false;
			// Получаем компонент SpriteRenderer у объекта, который вошел в триггер
			SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();

			if (spriteRenderer != null)
			{
				if (!isOrderChanged)
				{
					// Сохраняем текущий OrderInLayer
					savedOrderInLayer = spriteRenderer.sortingOrder;

					// Устанавливаем новый OrderInLayer
					spriteRenderer.sortingOrder = newOrderInLayer;

					// Устанавливаем флаг, что OrderInLayer был изменен
					isOrderChanged = true;
				}
				else
				{
					// Возвращаем сохраненный OrderInLayer
					spriteRenderer.sortingOrder = savedOrderInLayer;

					// Сбрасываем флаг
					isOrderChanged = false;
				}
			}
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("ActorTag") && flag == false)
		{
			flag = true;
		}

	}
}