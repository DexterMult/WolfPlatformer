using UnityEngine;

public class textPanelScript : MonoBehaviour
{
    public GameObject textPanel;



    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ������ �������
        if (other.CompareTag("HeroeTag") && textPanel != null) // ���������, ��� � ������ ������ ���������� ��� "Player"
        {
            textPanel.SetActive(true); // ���������� ������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ���������, ������� �� ����� �������
        if (other.CompareTag("HeroeTag") && textPanel != null)
        {
            textPanel.SetActive(false); // �������� ������
        }
    }
    private void Start()
    {
        // �������� ������ ��� ������
        textPanel.SetActive(false);
    }

}
