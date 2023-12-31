using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;  // Reference to the pause menu panel in the UI
    public static bool isGamePaused = false;  // Indicates whether the game is currently paused

    public void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // Check for the "Escape" key to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        // Hide the pause menu panel
        pauseMenuPanel.SetActive(false);

        // Resume the game by setting the time scale to 1 (normal time)
        //Time.timeScale = 1f;

        // Update the pause status
        isGamePaused = false;
    }

    public void PauseGame()
    {
        // Show the pause menu panel
        pauseMenuPanel.SetActive(true);

        // Pause the game by setting the time scale to 0 (no time)
        //Time.timeScale = 0f;

        // Update the pause status
        isGamePaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
