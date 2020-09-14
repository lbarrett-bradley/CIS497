/*
 * Liam Barrett
 * Prototype 2
 * Destroys projectile or animal if they go out of bounds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private HealthSystem healthSystemScript;
    public float topBound = 20;
    public float bottomBound = -10;

    void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Separating the food from the animals going out of bounds
        // Food goes out of bounds
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        // Animals go out of bounds
        if (transform.position.z < bottomBound)
        {
            //grab the health system script and call TakeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }
    }
}
