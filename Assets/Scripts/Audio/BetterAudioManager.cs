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
            PlayMusic("MainMenuTheme");
        }

        public void PlaySFX(string sfxName)
        {
            var sound = FindSoundByName(sfxName, sfxSound);
            PlaySound(sfxSource, sound);
        }

        public void PlayMusic(string musicName)
        {
            var sound = FindSoundByName(musicName, musicSound);

            if (sound != null)
            {
                PlaySound(musicSource, sound);

                // Schedule the transition to the second music after the first one finishes
                Invoke(nameof(StartSecondMusic), musicSource.clip.length);
            }
            else
            {
                Debug.Log("Music Not Found");
            }
        }

        private void StartSecondMusic()
        {
            StopAndPlayMusic("SecondMusicTheme", true);
        }

        public void PlayAmbient(string ambientName)
        {
            var sound = FindSoundByName(ambientName, ambientSound);
            PlaySound(ambientSource, sound);
        }

        public void MusicVolume(float volume)
        {
            SetVolume(musicSource, volume);
        }

        public void SFXVolume(float volume)
        {
            SetVolume(sfxSource, volume);
        }

        private static void PlaySound(AudioSource audioSource, Sound sound)
        {
            if (audioSource != null && sound != null)
            {
                audioSource.clip = sound.clip;
                audioSource.Play();
            }
        }

        private void StopAndPlayMusic(string musicName, bool loop)
        {
            musicSource.Stop();
            var sound = FindSoundByName(musicName, musicSound);

            if (sound != null)
            {
                musicSource.clip = sound.clip;
                musicSource.loop = loop;
                musicSource.Play();
            }
            else
            {
                Debug.Log("Music Not Found");
            }
        }

        private static void SetVolume(AudioSource audioSource, float volume)
        {
            if (audioSource != null)
            {
                audioSource.volume = volume;
            }
        }

        private static Sound FindSoundByName(string soundName, Sound[] soundArray)
        {
            return Array.Find(soundArray, x => x.name == soundName);
        }
    }
}
