/*
 * Liam Barrett
 * Prototype 3
 * Controls looping of background
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    void Start()
    {
        //save the starting position of the background to a Vector3 variable
        startPosition = transform.position;

        //set the repeatWidth to half of the width of the background using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        //if the background is farther to the left than the repeatWidth, reset it to startPosition
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
