using UnityEngine;

namespace UI
{
    /// <summary>
    ///     This script is in charge of playing music in the game
    /// </summary>
    public class MusicPlayer : MonoBehaviour
    {

        [SerializeField] private AudioClip menuMusic;
        [SerializeField] private AudioClip levelMusic;
        [SerializeField] private AudioSource source;
        
        public static MusicPlayer instance;

        private void Awake()
        {
            // Singleton enforcement
            if (instance == null)
            {
                // Register as singleton if first
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                // Self-destruct if another instance exists
                Destroy(this);
            }
        }

        private void Start()
        {
            // If the game starts in a menu scene, play the appropriate music
            PlayMenuMusic();
        }
        
        public static void PlayMenuMusic()
        {
            if (instance != null)
            {
                if (instance.source != null)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.menuMusic;
                    instance.source.Play();
                }
            }
            else
            {
                Debug.LogError("Unavailable MusicPlayer component");
            }
        }
        
        public static void PlayGameMusic()
        {
            if (instance != null)
            {
                if (instance.source != null)
                {
                    instance.source.Stop();
                    instance.source.clip = instance.levelMusic;
                    instance.source.Play();
                }
            }
            else
            {
                Debug.LogError("Unavailable MusicPlayer component");
            }
        }
    }
}