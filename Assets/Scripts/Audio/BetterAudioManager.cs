using System;
using UnityEngine;

namespace Audio
{
    public class BetterAudioManager : MonoBehaviour
    {
        public Sound[] sfxSound;
        public AudioSource musicSource, sfxSource;

        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip levelMusic;
        //[SerializeField] private AudioSource source;

        public static BetterAudioManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            PlayMenuMusic();
        }

        public void PlaySFX(string soundName)
        {
            var sound = Array.Find(sfxSound, x => x.name == name);

            if (sound == null)
                Debug.Log("Sound Not Found");
            else
                sfxSource.PlayOneShot(sound.clip);
        }


        public static void PlayMenuMusic()
        {
            if (instance.musicSource != null)
            {
                instance.musicSource.Stop();
                instance.musicSource.clip = instance.menuMusic;
                instance.musicSource.Play();
            }
            else
            {
                Debug.LogError("Unavailable MusicPlayer component");
            }
        }

        public static void PlayGameMusic()
        {
            if (instance.musicSource != null)
            {
                instance.musicSource.Stop();
                instance.musicSource.clip = instance.levelMusic;
                instance.musicSource.Play();
            }
            else
            {
                Debug.LogError("Unavailable MusicPlayer component");
            }
        }

        public void MusicVolume(float volume)
        {
            musicSource.volume = volume;
        }
        
        public void SFXVolume(float volume)
        {
            sfxSource.volume = volume;
        }
    }
}