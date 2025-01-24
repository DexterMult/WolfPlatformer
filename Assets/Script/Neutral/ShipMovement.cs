using UnityEngine;
using System.Collections.Generic;

public class ShipMovement : MonoBehaviour
{
	public Transform pointA; // Точка A (начальная позиция)
	public Transform pointB; // Точка B (целевая позиция)
	public float speed = 5f; // Скорость движения корабля
	public Animator anim; // Ссылка на аниматор

	private List<RunRaven> ravens = new List<RunRaven>(); // Список скриптов RunRaven
	private bool isMoving = false; // Флаг для отслеживания движения корабля
	private bool hasReachedPointB = false; // Флаг для отслеживания достижения точки B
	private bool isMoveAfterKill = true;

	void Start()
	{
		// Находим все объекты с тегом "EnemyRaven" и добавляем их скрипты RunRaven в список
		GameObject[] enemyRavens = GameObject.FindGameObjectsWithTag("EnemyRaven");
		foreach (GameObject raven in enemyRavens)
		{
			RunRaven runRaven = raven.GetComponent<RunRaven>();
			if (runRaven != null)
			{
				ravens.Add(runRaven);
			}
		}
	}

	void Update()
	{
		if (hasReachedPointB) return; // Если корабль достиг точки B, прекращаем выполнение Update

		// Проверяем, есть ли объекты с actorDetect == true
		bool shouldStop = CheckRavensForActorDetect();

		if (isMoving)
		{
			if (shouldStop)
			{
				StopShip();
			}
			else
			{
				MoveShip();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("ActorTag"))
		{
			StartShip();
		}
	}

	void StartShip()
	{
		if (!isMoving && !hasReachedPointB && isMoveAfterKill)
		{
			isMoving = true;
			anim.SetTrigger("Start"); // Запускаем анимацию
		}
	}

	void StopShip()
	{
		if (isMoving)
		{
			isMoveAfterKill =false;
			isMoving = false;
			anim.SetTrigger("Stop"); // Останавливаем анимацию
		}
	}

	void MoveShip()
	{
		// Двигаем корабль к точке B
		transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

		// Проверяем, достиг ли корабль точки B
		if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
		{
			hasReachedPointB = true;
			StopShip(); // Останавливаем корабль и анимацию
		}
	}

	bool CheckRavensForActorDetect()
	{
		// Удаляем null-объекты из списка
		ravens.RemoveAll(raven => raven == null);

		// Проверяем, есть ли объекты с actorDetect == true
		foreach (RunRaven raven in ravens)
		{
			if (raven.actorDetect)
			{
				return true; // Если найден объект с actorDetect == true, возвращаем true
			}
		}
isMoveAfterKill = true;
		return false; // Если ни у одного объекта нет actorDetect == true, возвращаем false
	}
}