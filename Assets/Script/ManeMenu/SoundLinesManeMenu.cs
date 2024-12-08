using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundLinesManeMenu : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public bool isSound;
    public Image fillImage; // Ссылка на компонент Image
    private RectTransform rectTransform;
    private float normalizedX;





    void Start()
    {

        rectTransform = GetComponent<RectTransform>();
        if (isSound == true)
        {
            normalizedX = PlayerPrefs.GetFloat("soundVolume");
            SoundVolume();
            fillImage.fillAmount = Mathf.Clamp01(normalizedX);
        }
        else if (isSound == false)
        {
            normalizedX = PlayerPrefs.GetFloat("musicVolume");
            MusicVolume();
            fillImage.fillAmount = Mathf.Clamp01(normalizedX);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateFillAmount(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateFillAmount(eventData);
    }

    public void MusicVolume()
    {

        PlayerPrefs.SetFloat("musicVolume", normalizedX);

    }

    public void SoundVolume()
    {

        PlayerPrefs.SetFloat("soundVolume", normalizedX);
    }

    private void UpdateFillAmount(PointerEventData eventData)
    {
        // Получаем позицию курсора относительно RectTransform
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            // Нормализуем координаты
            normalizedX = (localPoint.x / rectTransform.rect.width) + 0.5f; // Приводим к диапазону [0, 1]
            fillImage.fillAmount = Mathf.Clamp01(normalizedX); // Устанавливаем значение fill amount
            if (isSound == true)
            {
                SoundVolume();
            }
            else if (isSound == false)
            {
                MusicVolume();
            }
        }
    }
}
