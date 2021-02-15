/*
 * Liam Barrett
 * WinZone.cs
 * Spring Assignment 2
 * Detects when the player enters the win zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    public bool touchPlayer;

    void Start()
    {
        touchPlayer = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player entered win zone");
        touchPlayer = true;
    }
}
