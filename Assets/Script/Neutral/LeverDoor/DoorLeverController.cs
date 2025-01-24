using UnityEngine;

public class DoorLeverController : MonoBehaviour
{
	// Публичные переменные
	public Animator doorAnim; // Аниматор двери
	public Animator leverAnim; // Аниматор рычага
	public Collider2D doorCollider; // Коллайдер двери

	private bool hasTriggered = false; // Флаг для отслеживания, было ли событие обработано

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Актор");
		// Проверяем, что объект, вошедший в триггер, имеет тег "ActorTag" и что событие еще не было обработано
		if (other.CompareTag("ActorTag") && !hasTriggered)
		{
			// Устанавливаем флаг, чтобы код не выполнялся повторно
			hasTriggered = true;

			// Отключаем коллайдер двери
			if (doorCollider != null)
			{
				doorCollider.enabled = false;
			}

			// Включаем анимацию открытия двери
			if (doorAnim != null)
			{
				doorAnim.SetTrigger("Open");
			}

			// Включаем анимацию активации рычага
			if (leverAnim != null)
			{
				leverAnim.SetTrigger("Enable");
			}
		}
	}
}