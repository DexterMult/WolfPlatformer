using UnityEngine;

public class BonusMov : MonoBehaviour
{
    private Vector3 startPosition; // ��������� ������� �������
    public float moveDistance;
    public float speed;
    private bool movingDown = true; // ���� ��� ����������� ��������

    void Start()
    {
        moveDistance = 0.3f;
        speed = 0.7f;
        startPosition = transform.position;
    }

    void Update()
    {
        // ���������� ����� ��������� � ����������� �� ����������� ��������
        if (movingDown)
        {
            // ������� ������ ����
            transform.position += Vector3.down * speed * Time.deltaTime;

            // ���������, �������� �� �� ������ �������
            if (transform.position.y <= startPosition.y - moveDistance)
            {
                movingDown = false; // ������ ����������� �� �����
            }
        }
        else
        {
            // ������� ������ �����
            transform.position += Vector3.up * speed * Time.deltaTime;

            // ���������, �������� �� �� ������� �������
            if (transform.position.y >= startPosition.y)
            {
                movingDown = true; // ������ ����������� �� ����
            }
        }
    }
}
