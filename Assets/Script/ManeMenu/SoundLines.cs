using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundLines : MonoBehaviour
{
	public Image image;
	private bool isDragging = false; // Флаг для отслеживания, перетаскивается ли мышь

	private void OnEnable()
	{
		image.fillAmount = PlayerPrefs.GetFloat("musicVolume"); // При активации окна Setting устанавливаем длину линии в соответствии с сохранением
	}
	private void Update()
	{
		// Проверяем, нажата ли левая кнопка мыши
		if (Input.GetMouseButtonDown(0))
		{
			// Начинаем перетаскивание, если мышь на элементе UI
			isDragging = IsMouseOverImage();
		}

		// Проверка, отпущена ли левая кнопка мыши
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false; // Останавливаем перетаскивание
		}

		// Если мышь перетаскивается, меняем fillAmount
		if (isDragging)
		{
			ChangeFillAmountMusic();
		}
	}

	private bool IsMouseOverImage()
	{
		// Проверка, находится ли мышь над элементом Image
		Vector2 mousePos = Input.mousePosition;
		RectTransform rectTransform = image.GetComponent<RectTransform>();
		return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos);
	}

	private void ChangeFillAmountMusic()
	{
		// Получаем позицию мыши в локальных координатах
		Vector2 mousePos = Input.mousePosition;
		RectTransform rectTransform = image.GetComponent<RectTransform>();

		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePos, null, out localPoint);

		// Вычисляем значение fillAmount на основе позиции относительно размера RectTransform
		float fillAmount;

		// Если тип изображения "Filled" - Horizontal
		if (image.type == Image.Type.Filled && image.fillMethod == Image.FillMethod.Horizontal)
		{
			fillAmount = Mathf.Clamp01((localPoint.x + (rectTransform.rect.width / 2)) / rectTransform.rect.width);
			PlayerPrefs.SetFloat("musicVolume", fillAmount);//каждый раз сохраняем громкость музыки
			PlayerPrefs.Save();
			SoundEvents.SetMusicVolume();
		}
		// Если тип изображения "Filled" - Vertical
		else if (image.type == Image.Type.Filled && image.fillMethod == Image.FillMethod.Vertical)
		{
			fillAmount = Mathf.Clamp01((localPoint.y + (rectTransform.rect.height / 2)) / rectTransform.rect.height);
		}
		else
		{
			fillAmount = 0; // По умолчанию, если тип другой
		}
		// Устанавливаем значение fillAmount
		image.fillAmount = fillAmount;
	}
}
