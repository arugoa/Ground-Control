using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObjects : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject monitor;
    public GameObject radio;
    public GameObject folder;
    public List<GameObject> everythingElse = new List<GameObject>();

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
