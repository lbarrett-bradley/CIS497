/*
 * Liam Barrett
 * Assignment 5
 * Displays "You Win!" when player walks into trigger zone
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text winText;

    private void Start()
    {
        winText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        winText.text = "You Win!";
    }
}
