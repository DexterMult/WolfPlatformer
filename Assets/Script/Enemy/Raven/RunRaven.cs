using UnityEngine;

public class RunRaven : MonoBehaviour
{
    private FlipRaven flipRaven;
    private bool isFacingRight;
    public Transform point1; // Первая точка
    public Transform point2; // Вторая точка
    private float speed = 4f; // Скорость перемещения
    private GroundChecker groundChecker;

    public Transform transformActor;
    public bool actorDetect;

    private Vector3 targetPosition; // Целевая позиция для перемещения

    void Start()
    {
        isFacingRight = true;
        // Устанавливаем начальную целевую позицию на point2
        actorDetect = false;
        targetPosition = point2.position;
        flipRaven = GetComponent<FlipRaven>();
    }

    private void RunToTarget()
    {
        if (actorDetect == false)
        {
            // Перемещаем объект к целевой позиции
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if ((transform.position.x < targetPosition.x) && isFacingRight == true) return;
            else if ((transform.position.x > targetPosition.x) && isFacingRight == false) return;
            else
            {
                flipRaven.Flip();
                isFacingRight = !isFacingRight;
            }
            // Проверяем, достигли ли мы целевой позиции
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Меняем целевую позицию на противоположную
                targetPosition = targetPosition == point1.position ? point2.position : point1.position;
            }
        }
    }

    private void RunToActor()
    {
        if (actorDetect == true && groundChecker.isDeath == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, transformActor.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, transformActor.position) > 15f)
            {
                actorDetect = false;
            }
            if ((transform.position.x < transformActor.position.x) && isFacingRight == true) return;
            else if ((transform.position.x > transformActor.position.x) && isFacingRight == false) return;
            else
            {
                flipRaven.Flip();
                isFacingRight = !isFacingRight;
            }
        }
        else if (actorDetect == true && groundChecker.isDeath == true)
        {
            actorDetect = false;
        }
    }
    void Update()
    {
        RunToTarget();
        RunToActor();
    }
    public void SetActorTarget(Transform transformActor, bool actorDetect)
    {
        this.transformActor = transformActor;
        this.actorDetect = actorDetect;
    }

    public void SetGroundChecker(GroundChecker groundChecker)
    {
        this.groundChecker = groundChecker;
    }

}
