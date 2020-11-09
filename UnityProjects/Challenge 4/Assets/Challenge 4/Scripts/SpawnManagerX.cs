using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int enemyScoreCount;
    public int waveCount = 0;
    public int enemySpeed = 20;

    public Text waveText;
    public Text gameOverText;
    public Text tutorialText;

    private bool tutorialComplete;

    public GameObject player;

    void Start()
    {
        gameOverText.text = "";
        tutorialComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialComplete)
        {
            Time.timeScale = 0;
            tutorialText.text = "Push all the soccer balls into the goal while avoiding them scoring on you. Beat 10 waves to win. Press Space to start";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialComplete = true;
                Time.timeScale = 1;
                tutorialText.text = "";
            }
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        waveText.text = "Wave: " + waveCount;

        if (enemyScoreCount == waveCount)
        {
            gameOverText.text = "You Lose! Press R to Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (enemyCount == 0)
        {
            if (waveCount >= 10)
            {
                gameOverText.text = "You Win! Press R to Restart";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
            else
            {
                SpawnEnemyWave(waveCount);
            }
        }
    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end

        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        waveCount++;
        enemySpeed += 5;
        ResetPlayerPosition(); // put player back at start

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
