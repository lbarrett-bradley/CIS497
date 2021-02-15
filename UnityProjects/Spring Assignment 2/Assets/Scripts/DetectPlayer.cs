/*
 * Liam Barrett
 * DetectPlayer.cs
 * Spring Assignment 2
 * Detects the player when they enter camera view and has the Subject update the observers
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player seen by camera");
        gameManager.securityCam.notifyObservers();
    }
}
