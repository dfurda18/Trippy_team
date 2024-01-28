using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] musicSound, sfxSound;
        public AudioSource musicSource, sfxSource;

        private static AudioManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            PlayMusic("MainMenuTheme");
        }

        public void PlayMusic(string soundName)
        {
            var sound = Array.Find(musicSound, x => x.name == name);

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

        public void PlaySFX(string soundName)
        {
            var sound = Array.Find(musicSound, x => x.name == name);

            if (sound == null)
                Debug.Log("Sound Not Found");
            else
                sfxSource.PlayOneShot(sound.clip);
        }
    }
}