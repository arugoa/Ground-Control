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
