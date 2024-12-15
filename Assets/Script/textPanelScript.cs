using UnityEngine;

public class textPanelScript : MonoBehaviour
{
    public GameObject textPanel;



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("HeroeTag") && textPanel != null) // Убедитесь, что у вашего игрока установлен тег "Player"
        {
            textPanel.SetActive(true); // Показываем панель
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Проверяем, покинул ли игрок триггер
        if (other.CompareTag("HeroeTag") && textPanel != null)
        {
            textPanel.SetActive(false); // Скрываем панель
        }
    }
    private void Start()
    {
        // Скрываем панель при старте
        textPanel.SetActive(false);
    }

}
