using System.Collections;
using UnityEngine;

public class Sounds : MonoBehaviour
{
	public AudioClip[] sounds;
	public AudioSource audioSorce;
	public AudioSource MusicAudioSorce;
	public AudioSource WalkAudioSorce;
	public AudioSource WalkAudioSorce2;
	public AudioSource BackAudioSorce;
	private bool isStartVolumChange = false; //было ли изменено значение громкости МУЗЫКИ в начале?
	private bool isStartSoundVolumeChange = false; //было ли изменено значение громкости ЗВУКОВ в начале?
	public void PlayMusic(AudioClip clip)
	{
		MusicAudioSorce.PlayOneShot(clip);
		MusicAudioSorce.volume = PlayerPrefs.GetFloat("musicVolume") * 0.005f;
	}
	public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false)
	{
		audioSorce.PlayOneShot(clip, volume);
	}
	public void PlayBackSound(AudioClip clip, float volume = 1f, bool destroyed = false)
	{
		BackAudioSorce.PlayOneShot(clip, volume);
	}
	public void PlaySoundWalk(AudioClip clip, float volume = 1f, bool destroyed = false)
	{
		WalkAudioSorce.PlayOneShot(clip, volume);
	}
	public void PlaySoundWalk2(AudioClip clip, float volume = 1f, bool destroyed = false)
	{
		WalkAudioSorce2.PlayOneShot(clip, volume);
	}

	private void Start()
	{
		PlayMusic(sounds[0]);
		StartCoroutine(PlaySoundAfterDelay());
		StartCoroutine(PlaySoundAfterDelayHowling());
		SoundEvents.ActionJump += PlayJump;
		SoundEvents.ActionDeath += PlayDeath;
		SoundEvents.ActionHit += PlayHit;
		SoundEvents.ActionWin += PlayWin;
		SoundEvents.ActionEnemyAtack += PlayEnemyAtack;
		SoundEvents.ActionTramplinJump += PlayTramplinJump;
		SoundEvents.ActionStarsSparkling += PlayStarsSparkling;
		SoundEvents.ActionLeaves += PlayLeaves;
		SoundEvents.ActionWalk += PlayWalk;
		SoundEvents.ActionStartGame += PlayStartGame;
		SoundEvents.ActionHowling += PlayHowling;
		SoundEvents.ActionPausedMusic += PausedMusicAudioSorce;
		SoundEvents.ActionUnPausedMusic += UnPausedMusicAudioSorce;
		SoundEvents.ActionMiniWaterSplash += PlayWaterWalk;
		SoundEvents.ActionBigEnteriWaterSplash += PlayWaterEnter;
		SoundEvents.ActionBigExitWaterSplash += PlayWaterExit;
	}
	private void OnEnable()
	{
		SoundEvents.ActionEat += PlayEat;
		SoundEvents.ActionChangeMusicVolume += SetMusicVolume;
		SoundEvents.ActionChangeSoundVolume += SetSoundVolume;
		SoundEvents.ActionChangeWalkVolume += SetWalkVolume;
		SoundEvents.ActionChangeBackVolume += SetBackVolume;
	}
	private void OnDestroy()
	{
		SoundEvents.ActionChangeMusicVolume -= SetMusicVolume;
		SoundEvents.ActionChangeSoundVolume -= SetSoundVolume;
		SoundEvents.ActionChangeWalkVolume -= SetWalkVolume;
		SoundEvents.ActionChangeBackVolume -= SetBackVolume;
		SoundEvents.ActionPausedMusic -= PausedMusicAudioSorce;
		SoundEvents.ActionUnPausedMusic -= UnPausedMusicAudioSorce;

		SoundEvents.ActionJump -= PlayJump;
		SoundEvents.ActionDeath -= PlayDeath;
		SoundEvents.ActionHit -= PlayHit;
		SoundEvents.ActionWin -= PlayWin;
		SoundEvents.ActionEnemyAtack -= PlayEnemyAtack;
		SoundEvents.ActionTramplinJump -= PlayTramplinJump;
		SoundEvents.ActionStarsSparkling -= PlayStarsSparkling;
		SoundEvents.ActionEat -= PlayEat;
		SoundEvents.ActionLeaves -= PlayLeaves;
		SoundEvents.ActionWalk -= PlayWalk;
		SoundEvents.ActionStartGame -= PlayStartGame;
		SoundEvents.ActionHowling -= PlayHowling;
		SoundEvents.ActionMiniWaterSplash -= PlayWaterWalk;
		SoundEvents.ActionBigEnteriWaterSplash -= PlayWaterEnter;
		SoundEvents.ActionBigExitWaterSplash -= PlayWaterExit;
	}
	private void Update()
	{
		SetStartVolumeChange();
		SetStartSoundVolumeChange();
	}

	private void SetStartVolumeChange()
	{
		if (isStartVolumChange == false)
		{
			SetMusicVolume();
			isStartVolumChange = true;
		}
	}
	private void PausedMusicAudioSorce()
	{
		if (MusicAudioSorce.isPlaying == true)
		{
			MusicAudioSorce.Pause();
		}
	}
	private void UnPausedMusicAudioSorce()
	{
		if (MusicAudioSorce.isPlaying == false)
		{
			MusicAudioSorce.UnPause();
		}
	}
	private void SetStartSoundVolumeChange()
	{
		if (isStartSoundVolumeChange == false)
		{
			SetSoundVolume();
			SetWalkVolume();
			SetBackVolume();
			isStartSoundVolumeChange = true;
		}
	}
	private void PlayJump()
	{
		PlaySound(sounds[1]);
	}
	private void PlayWalk()
	{
		PlaySoundWalk(sounds[2]);
	}
	private void PlayWaterWalk()
	{
		void PlayWaterWalk1()
		{
			PlaySoundWalk(sounds[13], Random.Range(0.2f, 1f));
		}
		void PlayWaterWalk2()
		{
			PlaySoundWalk2(sounds[14], Random.Range(0.2f, 1f));
		}
		int randomNumber = Random.Range(0, 2);
		if (randomNumber == 0)
		{
			PlayWaterWalk1();
		}
		else if (randomNumber == 1)
		{
			PlayWaterWalk2();
		}
	}
	private void PlayWaterEnter()
	{
		PlaySound(sounds[15], Random.Range(0.5f,1f));
	}
	private void PlayWaterExit()
	{
		PlaySound(sounds[16], Random.Range(0.5f,1f));
	}
	private void PlayHit()
	{
		PlaySound(sounds[3]);
	}

	private void PlayWin()
	{
		PlaySound(sounds[5]);
	}
	private void PlayDeath()
	{
		PlaySound(sounds[6]);
	}
	private void PlayEat()
	{
		PlaySound(sounds[7]);
	}
	private void PlayEnemyAtack()
	{
		PlaySound(sounds[4]);
	}
	private void PlayTramplinJump()
	{
		PlaySound(sounds[8]);
	}
	private void PlayStarsSparkling()
	{
		PlaySound(sounds[9]);
	}
	private void PlayLeaves()
	{
		PlaySound(sounds[10]);
	}
	private void PlayStartGame()
	{
		PlayBackSound(sounds[11]);
	}
	private void PlayHowling()
	{
		PlayBackSound(sounds[12]);
	}


	private void SetMusicVolume()
	{
		MusicAudioSorce.volume = PlayerPrefs.GetFloat("musicVolume") * 0.05f;
	}
	private void SetSoundVolume()
	{
		audioSorce.volume = PlayerPrefs.GetFloat("soundVolume") * 0.5f;
	}
	private void SetWalkVolume()
	{
		WalkAudioSorce.volume = PlayerPrefs.GetFloat("soundVolume") * 0.5f;
	}
	private void SetBackVolume()
	{
		BackAudioSorce.volume = PlayerPrefs.GetFloat("soundVolume") * 0.5f;
	}

	private IEnumerator PlaySoundAfterDelay()
	{
		yield return new WaitForSeconds(0.5f);
		SoundEvents.SetActionStartGame();
	}
	private IEnumerator PlaySoundAfterDelayHowling()
	{
		int timeDelay = Random.Range(10, 15);
		yield return new WaitForSeconds(timeDelay);
		SoundEvents.SetActionHowling();
	}
}
