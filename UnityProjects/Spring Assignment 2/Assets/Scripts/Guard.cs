/*
 * Liam Barrett
 * Guard.cs
 * Spring Assignment 2
 * Controls the enemy Guard AI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public float speed;
    public bool wasNotified;
    public bool caughtPlayer;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        wasNotified = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wasNotified)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Caught Player");
        caughtPlayer = true;
    }
}
