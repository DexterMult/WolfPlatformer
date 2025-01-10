using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Healch : MonoBehaviour
{
	private HealthMonitor healthMonitor;
	public Image HP1;
	public Image HP2;
	public Image HP3;
	[Header("RGBA")]
	[SerializeField] private float R;
	[SerializeField] private float G;
	[SerializeField] private float A;
	[SerializeField] private float B;



	private void HPColorSwitcher(Image hitPoint)
	{
		hitPoint.color = new Color(R, G, B, A);
	}
	private void HealchDestroi()
	{
		if(healthMonitor.fullHP == 3)
		{
			return;
		}
		else if (healthMonitor.fullHP == 2)
		{
			HPColorSwitcher(HP3);
		}
		else if (healthMonitor.fullHP == 1)
		{
			HPColorSwitcher(HP3);
			HPColorSwitcher(HP2);
		}
		else
		{
			HPColorSwitcher(HP3);
			HPColorSwitcher(HP2);
			HPColorSwitcher(HP1);
		}
	}
	void Start()
	{
		healthMonitor = GameObject.Find("HealthMonitor").GetComponent<HealthMonitor>();
		R = 0.5f;
		G = 0;
		B = 0;
		A = 1;
	}
	void Update()
		{
		HealchDestroi();
		}

	}
