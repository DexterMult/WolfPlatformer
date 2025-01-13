using UnityEngine;

public class PausedGame : MonoBehaviour
{
	private GameObject soundListener;
	private AudioSource[] audioSources;
	private void GetAllAudioSources()
	{
		soundListener = GameObject.Find("SoundListener");
		audioSources = soundListener.GetComponents<AudioSource>();
	}

	private void PausedAllSounds()
	{
		GetAllAudioSources();
		foreach (AudioSource audioSource in this.audioSources)
		{
			if (audioSource != null)
			{
				audioSource.Pause();
			}
		}
	}
	private void UnPausedAllSounds()
	{
		foreach (AudioSource audioSource in this.audioSources)
		{
			if (audioSource != null)
			{
				audioSource.UnPause();
			}
		}
	}
	
	public void PauseGame()
	{
		SoundEvents.SetActionPausedMusic();
		Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		SoundEvents.SetActionUnPausedMusic();
		Time.timeScale = 1f;
	}
}
