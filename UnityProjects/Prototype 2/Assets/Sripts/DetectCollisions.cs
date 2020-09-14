/*
 * Liam Barrett
 * Prototype 2
 * Destroys projectile and animal if they collide, incrementing the score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach to food projectile prefab
public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
