using UnityEngine;

public class BonusMov : MonoBehaviour
{
    private Vector3 startPosition; // Начальная позиция объекта
    public float moveDistance;
    public float speed;
    private bool movingDown = true; // Флаг для направления движения

    void Start()
    {
        moveDistance = 0.3f;
        speed = 0.7f;
        startPosition = transform.position;
    }

    void Update()
    {
        // Определяем новое положение в зависимости от направления движения
        if (movingDown)
        {
            // Двигаем объект вниз
            transform.position += Vector3.down * speed * Time.deltaTime;

            // Проверяем, достигли ли мы нижней границы
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingDown = false; // Меняем направление на вверх
            }
        }
        else
        {
            // Двигаем объект вверх
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Проверяем, достигли ли мы верхней границы
            if (transform.position.y >= startPosition.y)
            {
                movingDown = true; // Меняем направление на вниз
            }
        }
    }
}
