using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using Environment;
using UnityEngine;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        private GenerateLevel _generateLevel;
        
        private void Awake()
        {
            //DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            _generateLevel = FindObjectOfType<GenerateLevel>();
        }

        public void PlayButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(1);
            // if (_generateLevel != null)
            // {
            //     _generateLevel.ResetGenerationCoroutine();
            // }
            // else
            // {
            //     Debug.LogError("ProceduralGeneration script not found!");
            // }
            //SceneManager.LoadScene("SampleScene");
            BetterAudioManager.PlayGameMusic();
            
        }

        public void BackToMainMenuButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(0);
            // if (_generateLevel != null)
            // {
            //     _generateLevel.ResetGenerationCoroutine();
            // }
            // else
            // {
            //     Debug.LogError("ProceduralGeneration script not found!");
            // }
            BetterAudioManager.PlayMenuMusic();
        }

        public void ExitButton()
        {
            Application.Quit();
            Debug.Log("Quitting the game");
        }
    }
}