using UnityEngine;

public class CircularPlatform : MonoBehaviour
{
    [Header("Движение")]
    public float radius = 2f;       // Радиус круга движения
    public float speed = 2f;        // Скорость движения
    public Transform centerPoint;  // Центральная точка вращения

    [SerializeField]private float angle = 0f;       // Текущий угол движения

    void Update()
    {
       
        angle += speed * Time.deltaTime;

        
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.position.y + Mathf.Sin(angle) * radius;

        
        transform.position = new Vector3(x, y, transform.position.z);
    }

    
    void OnDrawGizmosSelected()
    {
        if (centerPoint == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(centerPoint.position, radius);
    }
}