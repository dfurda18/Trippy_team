using System;
using UnityEngine;

namespace Audio
{
    public class BetterAudioManager : MonoBehaviour
    {
        public Sound[] musicSound, sfxSound, ambientSound;
        public AudioSource musicSource, sfxSource, ambientSource;

        public static BetterAudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Instance.PlayMusic("MainMenuTheme");
        }

        public void PlaySFX(string sfxName)
        {
            var sound = Array.Find(sfxSound, x => x.name == sfxName);

            if (sound == null)
                Debug.Log("Sound Not Found");
            else
                sfxSource.PlayOneShot(sound.clip);
        }

        public void PlayMusic(string musicName)
        {
            var sound = Array.Find(musicSound, x => x.name == musicName);

            if (sound == null)
            {
                Debug.Log("Sound Not Found");
            }
            else
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }
        
        
        public void PlayAmbient(string ambientName)
        {
            var sound = Array.Find(ambientSound, x => x.name == ambientName);

            if (sound == null)
            {
                Debug.Log("Sound Not Found");
            }
            else
            {
                ambientSource.clip = sound.clip;
                ambientSource.Play();
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