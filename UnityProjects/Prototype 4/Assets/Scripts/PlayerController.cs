﻿/*
 * Liam Barrett
 * Assignment 7
 * Controls movement of player and loss condition
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerup;
    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator;

    private bool gameOver;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //move our powerup indicator to the ground below our player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            gameOverText.text = "You Lose! Press R to Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with: " + collision.gameObject.name +
                " with powerup set to " + hasPowerup);

            //get a local reference to the enemy rb
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            //set a Vector3 with a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            //add force away from player
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
