﻿/*
 * Liam Barrett
 * Assignment 8
 * Makes the good and bad objects rise and fall on the screen and get destroyed when clicked
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        //add a force upwards multiplied by a randomized speed
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque (rotational force) with randomized xyz values
        targetRb.AddTorque(RandomTorque(), RandomTorque(), 
            RandomTorque(), ForceMode.Impulse);

        //set the position with a randomized x value
        transform.position = RandomSpawnPos();

        //set reference to game manager
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();       
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
