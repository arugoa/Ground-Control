using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioAnimation : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public Image image;
    bool frame = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToggleFrame", 0, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (frame)
        {
            image.sprite = frame1;
        }
        else
        {
            image.sprite = frame2;
        }
    }

    public void ToggleFrame()
    {
        frame = !frame;
    }
}
