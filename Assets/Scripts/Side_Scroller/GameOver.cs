using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public GameObject endGame;
    public ParticleSystem snow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(player);
            endGame.SetActive(true);
            SpawnObstacles.gameOver = true;
            GroundScroll.gameOver = true;
            snow.Pause();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Destroy(player);
            endGame.SetActive(true);
            SpawnObstacles.gameOver = true;
            GroundScroll.gameOver = true;
            snow.Pause();
        }
    }
}
