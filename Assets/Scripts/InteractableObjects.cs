using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InteractableObjects : MonoBehaviour
{
    
    // Different Frames
    public GameObject monitor;
    public GameObject crypto;
    public GameObject radio;
    public GameObject folder;
    public List<GameObject> everythingElse = new List<GameObject>();

    // For typing input
    public InputField inputField;

    // Counter for number of tasks completed
    public static int counter = 0;

    private void Update()
    {   
        // Checks if esc key is pressed, if yes it deactivates all UI screens for crypto,radio, folder and sets everything else active.  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (monitor.activeSelf || radio.activeSelf || folder.activeSelf)
            {
                monitor.SetActive(false);
                radio.SetActive(false);
                folder.SetActive(false);
                for (int i = 0; i < everythingElse.Count; i++)
                {
                    everythingElse[i].SetActive(true);
                }
            }
            else
            {
                OpenFolder();
            }
        }

        // Resets the inputField if the monitor is closed
        if (!crypto.activeSelf)
        {
            inputField.text = "";
        }

        // Checks if game over and we win!
        if (counter == 2)
        {
            SceneManager.LoadScene("EndScene");
            counter = 0;
        }
    }

    public void OpenFolder()
    {
        // Load the game scene
        folder.SetActive(true);
        for (int i = 0; i < everythingElse.Count; i++)
        {
            everythingElse[i].SetActive(false);
        }

    }
    public void OpenMonitor()
    {
        // Load the game scene
        monitor.SetActive(true);
        for (int i = 0; i < everythingElse.Count; i++)
        {
            everythingElse[i].SetActive(false);
        }

    }

    // Typing in the box
    public void TypeBox()
    {
        string userInput = inputField.text;

        if (userInput.ToLower() == "hallo")
        {
            crypto.SetActive(false);
            for (int i = 0; i < everythingElse.Count; i++)
            {
                everythingElse[i].SetActive(true);
            }

            counter++;
        }
    }

    public void OpenRadio()
    {
        // Load the game scene
        radio.SetActive(true);
        for (int i = 0; i < everythingElse.Count; i++)
        {
            everythingElse[i].SetActive(false);
        }

    }
}
