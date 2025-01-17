using UnityEngine;
using System;

public class ParticleCleaner : MonoBehaviour
{
 void OnApplicationQuit()
	{
		// Находим все объекты с тегом "ParticleTag"
		GameObject[] particles = GameObject.FindGameObjectsWithTag("ParticleTag");

		// Удаляем каждый найденный объект
		foreach (GameObject particle in particles)
		{
			Debug.Log(particle.name);
			Destroy(particle);
		}
	}
}
