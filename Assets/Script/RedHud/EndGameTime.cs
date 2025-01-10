using TMPro;
using UnityEngine;

public class EndGameTime : MonoBehaviour
{
	public TextMeshProUGUI _minutsTMP;
	public TextMeshProUGUI _secundTMP;
	public void TimeResult()
	{
		Timer timer = FindFirstObjectByType<Timer>();
		if (timer != null)
		{
			_minutsTMP.text = timer._minutsTMP.text;
			_secundTMP.text = timer._secundTMP.text;
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
			TimeResult();	
	}
	void Start()
	{
		_minutsTMP.text = "00";
		_secundTMP.text = "00";
	}


}
