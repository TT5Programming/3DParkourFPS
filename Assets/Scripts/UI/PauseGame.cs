using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI, HUD;
    public PlayerMovement playerMovement;
    public string settingsMenuName, mainMenuName;
    public GameHandler gameHandler;
    
    void Start()
    {
        gameIsPaused = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerMovement.enabled = false;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(settingsMenuName);
    }

    public void QuitGame()
    {
        gameHandler.Save();
        SceneManager.LoadScene(mainMenuName);
    }
}
