using UnityEngine;

public class textPanelScript : MonoBehaviour
{
    public GameObject textPanel; // ������ �� ������ � �������



    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, �������� �� ������ �������
        if (other.CompareTag("HeroeTag")) // ���������, ��� � ������ ������ ���������� ��� "Player"
        {
            Debug.Log("���");
            textPanel.SetActive(true); // ���������� ������
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ���������, ������� �� ����� �������
        if (other.CompareTag("HeroeTag"))
        {
            Debug.Log("����");
            textPanel.SetActive(false); // �������� ������
        }
    }
    private void Start()
    {
        // �������� ������ ��� ������
        textPanel.SetActive(false);
    }

    void Update()
    {
        
    }
}
