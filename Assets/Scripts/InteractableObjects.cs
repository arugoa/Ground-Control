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
    public GameObject radio;
    public GameObject folder;
    public List<GameObject> everythingElse = new List<GameObject>();

    // For typing input
    public InputField inputField;
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

        Debug.Log(userInput);

        if (userInput == "Hallo")
        {
            monitor.SetActive(false);
            for (int i = 0; i < everythingElse.Count; i++)
            {
                everythingElse[i].SetActive(true);
            }
        }
    }

    // Clearing the box if you close monitor
    public void ClearBox()
    {
        inputField.text = "";
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
