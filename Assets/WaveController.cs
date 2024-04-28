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
    float waveTolerance = 0.05f;
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

    // Start is called before the first frame update
    void Start()
    {
        targetAmplitude = Random.value * 0.75f + 0.25f;
        targetFrequency = Random.value * 0.75f + 0.25f;
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
            points[i] = new Vector3(xOffset + i*10.0f/resolution * xMult, yOffset + amplitude * Mathf.Sin(frequency * i*10.0f/resolution) * yMult, 1);
        }
        lineRenderer.SetPositions(points);

        targetLineRenderer.positionCount = resolution;

        Vector3[] targetPoints = new Vector3[resolution];
        for (int i = 0; i < resolution; i++)
        {
            targetPoints[i] = new Vector3(xOffset + i * 10.0f / resolution * xMult, yOffset + 0.82f + targetAmplitude * Mathf.Sin(targetFrequency * i * 10.0f / resolution) * yMult, 1);
        }
        targetLineRenderer.SetPositions(targetPoints);

        if (Mathf.Abs(amplitude - targetAmplitude) < waveTolerance && Mathf.Abs(frequency - targetFrequency) < waveTolerance)
        {
            InteractableObjects.counter++;
            bigRadio.SetActive(false);
            for (int i = 0; i < everythingElse.Count; i++)
            {
                everythingElse[i].SetActive(true);
            }
        }

    }
}
