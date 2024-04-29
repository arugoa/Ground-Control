using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    float amplitude = 1.0f;
    float frequency = 1.0f;
    float targetAmplitude = 1.0f;
    float targetFrequency = 1.0f;
    float oldTargetAmp = 1.0f;
    float oldTargetFreq = 1.0f;
    int resolution = 50;
    float xOffset = 0;
    float yOffset = 0;
    float waveTolerance = 0.6f;
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
    [SerializeField]
    Button TestButton;

    public List<GameObject> everythingElse = new List<GameObject>();

    // randomize target wave values
    private void RandomizeValues()
    {
        targetAmplitude = (Random.value * 0.25f + 0.75f) % 1.0f;
        targetFrequency = (Random.value * 0.25f + 0.75f * 4);


        /*
         Previous values:
         targetAmplitude = Random.value * 0.5f + 0.5f;
         targetFrequency = Random.value * 0.5f + 0.5f * 4;
         */
    }

    private void ReinitializeValues()
    {
        amplitude = 1.0f;
        frequency = 1.0f;
        amplitudeSlider.value = 0.5f;
        frequencySlider.value = 0.5f;
        RandomizeValues();
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
        Debug.Log("NEW TARG AMP: " + targetAmplitude);
        Debug.Log("NEW TARG FREQ: " + targetFrequency);
        
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
        /*Debug.Log("pressed.");
        Debug.Log("amplitude: " + amplitude);
        Debug.Log("target amp: " + targetAmplitude);
        Debug.Log("freq: " + targetFrequency);
        Debug.Log("target freq: " + frequency);*/

        float ampDiff = 1.0f;
        float freqDiff = 1.0f;

        if (Mathf.Abs(amplitude - targetAmplitude) < waveTolerance && Mathf.Abs(frequency - targetFrequency) < waveTolerance * 4)
        {
            if (InteractableObjects.radioCounter < 2) { InteractableObjects.radioCounter++; }

            bigRadio.SetActive(false);
            oldTargetAmp = targetAmplitude;
            oldTargetFreq = targetFrequency;
            
            Debug.Log("old targ amp: " + oldTargetAmp);
            Debug.Log("old targ freq: " + oldTargetFreq);
            ReinitializeValues();


            Debug.Log("rerandomized targ amp: " + targetAmplitude);
            Debug.Log("rerandomized targ freq: " + targetFrequency);
            ampDiff = Mathf.Abs(oldTargetAmp - targetAmplitude);
            freqDiff = Mathf.Abs(oldTargetFreq - targetFrequency);

            if(ampDiff < 0.5f && freqDiff < 0.5f) {
                targetAmplitude += 0.5f;
                targetAmplitude = targetAmplitude % 1.0f;
                /*targetFrequency += 0.5f;
                targetFrequency = targetFrequency % 1.0f;*/
            }

            Debug.Log("diff between old and new amp: " + ampDiff);
            Debug.Log("diff between old and new freq: " + freqDiff);

            Debug.Log("updated targ amp: " + targetAmplitude);
            Debug.Log("updated targ freq: " + targetFrequency);

            for (int i = 0; i < everythingElse.Count; i++)
            {
                everythingElse[i].SetActive(true);
            }
        }

        Debug.Log("radio.Counter: " + InteractableObjects.radioCounter);


    }
}
