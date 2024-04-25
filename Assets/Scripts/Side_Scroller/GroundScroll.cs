using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private MeshRenderer groundRenderer;
    public float speed;
    public float increaseSpeed;
    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        groundRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            speed += increaseSpeed * Time.deltaTime;
            float renderSpeed = speed / transform.localScale.x;
            groundRenderer.material.mainTextureOffset += Vector2.right * renderSpeed * Time.deltaTime;
        }
    }
}
