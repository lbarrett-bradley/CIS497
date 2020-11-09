/*
 * Liam Barrett
 * Assignment 7
 * Controls waves and enemy spawning
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;

    public int enemyCount;
    public int waveNumber = 1;

    public Text waveText;
    public Text gameOverText;
    public Text tutorialText;

    public bool tutorialComplete;

    // Start is called before the first frame update
    void Start()
    {
        tutorialComplete = false;
        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //instantiate the enemy in the random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            //instantiate the enemy in the random position
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialComplete)
        {
            Time.timeScale = 0;
            tutorialText.text = "Knock all the enemies off the platform to finish the wave. Complete 10 waves to win. Don't fall off. Press Space to Start";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialComplete = true;
                Time.timeScale = 1;
                tutorialText.text = "";
            }
        }
        else
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            waveText.text = "Wave: " + waveNumber;

            if (enemyCount == 0)
            {
                if (waveNumber >= 10)
                {
                    gameOverText.text = "You Win! Press R to Restart";
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
                else
                {
                    waveNumber++;
                    SpawnEnemyWave(waveNumber);
                    SpawnPowerup(1);
                }
            }
        }
    }
}
