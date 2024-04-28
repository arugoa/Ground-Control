using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FolderSwitching : MonoBehaviour
{
    public GameObject redFolder;
    public GameObject yellowFolder;
    public GameObject blueFolder;
    public int tab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        redFolder.SetActive(tab == 0);
        yellowFolder.SetActive(tab == 1);
        blueFolder.SetActive(tab == 2);
    }

    public void SetRedTab()
    {
        Debug.Log("red");
        tab = 0;
    }

    public void SetYellowTab()
    {
        Debug.Log("yellow");
        tab = 1;
    }

    public void SetBlueTab()
    {
        Debug.Log("blue");
        tab = 2;
    }
}
