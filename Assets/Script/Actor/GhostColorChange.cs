using UnityEngine;

public class GhostColorChange : MonoBehaviour
{
    private GroundChecker groundChecker;
    private SpriteRenderer spriteRenderer;


    private void SetColor()
    {
        if (groundChecker.isDeath == false)
        {
            if (groundChecker.isDamage == true)
            {
                spriteRenderer.color = Color.red;
            }
            else if (groundChecker.isDamage == false)
            {
                spriteRenderer.color = Color.white;
            }
            if (groundChecker.isGhost == true)
            {
                Color color = spriteRenderer.color;

                // ������������� �����-����� �� 50%
                color.a = 0.5f; // 50% ������������
                spriteRenderer.color = color; // ��������� ����� ���� � �������
            }
            else if (groundChecker.isGhost == false)
            {
                Color color = spriteRenderer.color;

                // ������������� �����-����� �� 50%
                color.a = 1f; // 50% ������������
                spriteRenderer.color = color; // ��������� ����� ���� � �������
            }
        }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundChecker = GetComponent<GroundChecker>();
    }

    void Update()
    {
        SetColor();
    }
}
