using UnityEngine;
using TMPro;
using System;
public class DialogHandler : MonoBehaviour
{
	public static event Action Dialog1;
	public static event Action Dialog2;
	public static event Action Dialog3;

	public static void StartDialog1()
	{
		Dialog1?.Invoke();
	}
	public static void StartDialog2()
	{
		Dialog2.Invoke();
	}
	public static void StartDialog3()
	{
		Dialog3.Invoke();
	}
}
