using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public GameObject instructionsPanel; // Reference to the instructions panel GameObject

    void Start()
    {
        // Hide the instructions panel when the game starts
        instructionsPanel.SetActive(false);
    }

    void Update()
    {
        // Hide the instructions panel if the 'Escape' key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            instructionsPanel.SetActive(false);
        }
    }

    public void StartGame()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(1);
    }

    public void ShowInstructions()
    {
        // Show the instructions panel
        instructionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        // Quit the game (only works in standalone builds)
        Application.Quit();
    }
}
