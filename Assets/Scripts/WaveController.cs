using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    float amplitude = 1.0f;
    float frequency = 1.0f;
    float targetAmplitude = 1.0f;
    float targetFrequency = 1.0f;
    int resolution = 50;
    float xOffset = 0;
    float yOffset = 0;
    float waveTolerance = 0.1f;
    public float length = 10.0f;
    [SerializeField]
    float xMult = 0.42f;
    [SerializeField]
    float yMult = 0.26f;
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    Slider amplitudeSlider;
    [SerializeField]
    Slider frequencySlider;
    [SerializeField]
    LineRenderer targetLineRenderer;
    [SerializeField]
    GameObject bigRadio;

    public List<GameObject> everythingElse = new List<GameObject>();

    private void RandomizeValues()
    {
        targetAmplitude = Random.value * 0.5f + 0.5f;
        targetFrequency = Random.value * 4 * 0.5f + 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeValues();
    }

    // Update is called once per frame
    void Update()
    {
        amplitude = amplitudeSlider.value;
        frequency = frequencySlider.value * 4;
        
        lineRenderer.positionCount = resolution;
        xOffset = this.transform.position.x;
        yOffset = this.transform.position.y;
        Vector3[] points = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            points[i] = new Vector3(xOffset + i*length/resolution * xMult, yOffset + amplitude * Mathf.Sin(frequency * i*length/resolution) * yMult, 1);
        }
        lineRenderer.SetPositions(points);

        targetLineRenderer.positionCount = resolution;

        Vector3[] targetPoints = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            targetPoints[i] = new Vector3(xOffset + i * length / resolution * xMult, yOffset + 0.82f + targetAmplitude * Mathf.Sin(targetFrequency * i * length / resolution) * yMult, 1);
        }
        targetLineRenderer.SetPositions(targetPoints);
    }

    public void TestRadio()
    {
        Debug.Log("pressed.");

        if (Mathf.Abs(amplitude - targetAmplitude) < waveTolerance && Mathf.Abs(frequency - targetFrequency) < waveTolerance)
        {
            RandomizeValues();
            InteractableObjects.radioCounter++;
            bigRadio.SetActive(false);
            for (int i = 0; i < everythingElse.Count; i++)
            {
                everythingElse[i].SetActive(true);
            }
        }
    }
}
