using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        public void PlayButton() // need to add ~1 sec delay because the sound of UnClicking getting cut
        {
            SceneManager.LoadSceneAsync(sceneBuildIndex: 1);
        }

        public void SettingsButton() // yet in progress
        {
            
        }

        public void ExitButton() // need to check on the build itself
        {
            Application.Quit();
            Debug.Log("Quitting the game");
        }
    }
}
