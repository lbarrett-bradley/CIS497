/*
 * Liam Barrett
 * GuardListener.cs
 * Spring Assignment 2
 * The observer class that allows the guard to be notified when the player is seen by the camera
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardListener : Observer
{
    public Guard guard = GameObject.FindGameObjectWithTag("Guard").GetComponent<Guard>();

    public void update()
    {
        guard.wasNotified = true;
    }
}
