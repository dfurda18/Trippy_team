using Audio;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGamePaused;
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private TextMeshProUGUI distanceCounterText;
    private PlayerMove player;

    public int dogDistanceCount = 5;// default distance of the dog of screen
    
    //get the player^^^ and the dog game objects 
    private FollowPlayer dog;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().GetComponent<PlayerMove>();

        dog = FindObjectOfType<FollowPlayer>().GetComponent<FollowPlayer>();

        // Start the coroutine to increase the dogDistanceCount every second
        StartCoroutine(IncreaseVariableRoutine());
    }

    public void Resume()
    {
        Cursor.visible = false; // makes the mouse insivible when playing
        Cursor.lockState = CursorLockMode.Locked;
        
        _pauseMenuUI.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    private void Pause()
    {
        Cursor.visible = true; // makes the mouse visible when press escape
        Cursor.lockState = CursorLockMode.None;

        _pauseMenuUI.SetActive(true);
        player.enabled = false;
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    /**
     * update the UI with the current counter
     */
    private void UpdateDistanceCounter()
    {
        // Update the TextMeshPro text with the current value of myVariable
        if (distanceCounterText != null)
        {
            distanceCounterText.text = dogDistanceCount.ToString();
        }
    }
    /**
     * The following code is for the dogs distance indicator.
     */
    private IEnumerator IncreaseVariableRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            // Increase the variable by 1 every second,but not beyond 30
            if (player.GetComponentInChildren<Animator>().GetBool("isRunning") && dogDistanceCount < 15)
            {
                dogDistanceCount++;
            }
            

            /**
             * if the player has collided with an obstacle and stopped running then shorten the distance
             */
            // Decrease the variable by 1 if the bool is true
            if (!player.GetComponentInChildren<Animator>().GetBool("isRunning"))
            {
                dogDistanceCount -= 2;
                // Ensure the variable doesn't go below 0
                dogDistanceCount = Mathf.Max(0, dogDistanceCount);
            }

            /**
             * run the dog ending attack animation if the player is not running AND the game has started AND the dog is within 5m
             */
            if(!player.GetComponentInChildren<Animator>().GetBool("isRunning") && dogDistanceCount < 5)
            {
                if (player.gameStart)
                {
                    //runs animation 
                    dog.GetComponent<Animator>().SetBool("dogIsClose", true);
                }
                dog.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            else
            {
                dog.GetComponentInChildren<MeshRenderer>().enabled = false;
                dog.GetComponent<Animator>().SetBool("dogIsClose", false);
            }

            // Update the UI TextMeshPro element
            UpdateDistanceCounter();
        }
    }


    private void DogCatchesPlayer()
    {
        //return to main menue
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (_isGamePaused)
                Resume();
            else
                Pause();
        }

        /**
         * The following code is for the dogs distance indicator.
         */

    }
}