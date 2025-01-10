using System.Collections;
using UnityEngine;

public class PGhost : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D BoxCollider2;

    [SerializeField]
    private float firstDuration;

    [SerializeField]
    private float cicleDuration;

    private bool isHidden;
    void Start()
    {
        isHidden = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2 = GetComponent<BoxCollider2D>();

        StartCoroutine(FirstDuration());
    }
    private void HiddenOn()
    {
        if (spriteRenderer != null)
        {
            // ������������� �����-����� �� 0 (������ ������������)
            Color color = spriteRenderer.color;
            color.a = 0; // ������������� �����-����� �� 0
            spriteRenderer.color = color;
        }
        if (BoxCollider2 != null)
        {
            // ��������� BoxCollider2D
            BoxCollider2.enabled = false;
        }
    }
    private void HiddenOff()
    {
        if (spriteRenderer != null)
        {
            // ������������� �����-����� �� 0 (������ ������������)
            Color color = spriteRenderer.color;
            color.a = 1; // ������������� �����-����� �� 0
            spriteRenderer.color = color;
        }
        if (BoxCollider2 != null)
        {
            // ��������� BoxCollider2D
            BoxCollider2.enabled = true;
        }
    }

    private IEnumerator FirstDuration()
    {
        if (isHidden == false)
        {
            yield return new WaitForSeconds(firstDuration);
            firstDuration = cicleDuration;
            HiddenOn();
            isHidden = true;
        }
        if (isHidden == true)
        {
            yield return new WaitForSeconds(firstDuration);
            HiddenOff();
            firstDuration = cicleDuration;
            isHidden = false;
        }
            StartCoroutine(FirstDuration());
    }

    
}
