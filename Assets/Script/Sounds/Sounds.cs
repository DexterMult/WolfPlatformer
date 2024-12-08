using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource audioSorce;
    public AudioSource MusicAudioSorce;

    public void PlayMusic(AudioClip clip)
    {
        MusicAudioSorce.PlayOneShot(clip);
        MusicAudioSorce.volume = PlayerPrefs.GetFloat("musicVolume");
    }
    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false)
    {
        audioSorce.PlayOneShot(clip, volume);
    }
    private void Start()
    {
        PlayMusic(sounds[0]);

    }

}
