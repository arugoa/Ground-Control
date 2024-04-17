using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void FinishGame()
    {
        // move to restart game screen
        SceneManager.LoadScene("EndScene");
    }

    public void RestartGame() 
    {
        // Load up the start again, and reset variables
        SceneManager.LoadScene("StartScene");

        // Reset variables
        
    }

    public void QuitGame()
    {
        // Quit the application (only works in standalone builds)
        Application.Quit();
    }
}