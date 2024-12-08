using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundLines : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public bool isSound;
    public GameObject AudioSorceObject;
    public Image fillImage; // Ссылка на компонент Image
    private RectTransform rectTransform;
    private float normalizedX;

    public Image soundLine;
    public Image musicLine;

    private AudioSource[] sorceSprings;


    void Start()
    {
        sorceSprings = AudioSorceObject.GetComponents<AudioSource>();

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
        sorceSprings[1].volume = normalizedX;
        PlayerPrefs.SetFloat("musicVolume", normalizedX);
        Debug.Log(PlayerPrefs.GetFloat("musicVolume"));
    }

    public void SoundVolume()
    {
        sorceSprings[0].volume = normalizedX;
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
