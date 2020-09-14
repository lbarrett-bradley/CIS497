﻿/*
 * Liam Barrett
 * Challenge 2
 * destroys dog and ball objects when they leave the screen and removes health
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private HealthSystem healthSystemScript;
    private float leftLimit = -30;
    private float bottomLimit = -5;

    void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }

    }
}
