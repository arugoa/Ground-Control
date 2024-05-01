using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void AstronautControlsScene()
    {
        SceneManager.LoadScene("AstronautControlsScene");
    }
    
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("MainScene");
    }
    public void AstronautGameScene()
    {
        //Load Platformer Scene
        SceneManager.LoadScene("AstronautGameScene");
    }
    public void FinishGame()
    {
        // move to restart game screen
        SceneManager.LoadScene("EndScene");
    }

    public void RestartGame() 
    {
        // Load up the start again, and reset variables
        SpawnObstacles.gameOver = false;
        GroundScroll.gameOver = false;
        SceneManager.LoadScene("StartScene");

        // Reset variables
        
    }

    public void QuitGame()
    {
        // Quit the application (only works in standalone builds)
        Application.Quit();
    }
}
