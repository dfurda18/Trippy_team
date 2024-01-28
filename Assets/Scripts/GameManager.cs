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
        player = FindObjectOfType<PlayerMove>();
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenuUI.SetActive(false);
        player.GetComponent<PlayerMove>().enabled = true;
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pauseMenuUI.SetActive(true);
        player.GetComponent<PlayerMove>().enabled = false;
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