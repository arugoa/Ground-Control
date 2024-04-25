using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    private int[] probabilities = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 };
    private int chance;
    public GameObject rockPrefab;
    public GameObject asteroidPrefab;
    public float rockSpeed;
    public float asteroidSpeed;
    public float rockTime;
    public float asteroidTime;
    public float spawnTime;
    public float timer;
    public float timerInit;
    public bool hit;
    private bool spawned=false;
    public GameObject reach;
    public GameObject obstacle;
    public float increaseSpeed;
    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameOver && !spawned)
        {
            timerInit = timer;
            InvokeRepeating("SpawnObstacle", 0, spawnTime);
        }
    }

    void SpawnObstacle()
    {
            spawned = true;

            chance = probabilities[Random.Range(0, probabilities.Length)];

            GameObject obstaclePrefab = (chance == 0) ? rockPrefab : asteroidPrefab;

            obstacle = Instantiate(obstaclePrefab, obstaclePrefab.transform.position, Quaternion.identity);
        if (!gameOver)
        {
            timer = (chance == 0) ? rockTime : asteroidTime;

            float speed = (chance == 0) ? rockSpeed : asteroidSpeed;

            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            rb.AddForce(-transform.right * speed);
        }
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (spawned)
            {
                timer -= Time.deltaTime;
            }
            if (timer < 0)
            {
                Destroy(obstacle);
                timer = timerInit;
                spawned = false;
            }
            asteroidSpeed += increaseSpeed;
            rockSpeed += increaseSpeed;
        }
        if (gameOver)
        {
            rockSpeed = 0;
            asteroidSpeed = 0;
            rockTime = 0;
            asteroidTime = 0;
            spawnTime = 0;
            timer = 0;
            timerInit = 0;
            increaseSpeed = 0;
            Destroy(obstacle);
        }
    }
}
