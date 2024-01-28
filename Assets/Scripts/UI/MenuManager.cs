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
        public void PlayButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(1);
            BetterAudioManager.Instance.PlayMusic("ChaseTheme");
            BetterAudioManager.Instance.PlayAmbient("WindAmbient");
        }

        public void BackToMainMenuButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(0);
            Destroy(BetterAudioManager.Instance.gameObject);
            BetterAudioManager.Instance.PlayMusic("MainMenuTheme");
        }

        public void ExitButton()
        {
            Application.Quit();
            Debug.Log("Quitting the game");
        }
    }
}