using Audio;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGamePaused;
    [SerializeField] private GameObject _pauseMenuUI;
    private PlayerMove player;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().GetComponent<PlayerMove>();
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
    }
}