/*
* Liam Barrett
* Assignment 1
* Adds points when the player collides with Trigger Zone
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerEnterTrigger : MonoBehaviour
{
    //public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trigger Zone"))
        {
            //textbox.text = "You Win!";
            ScoreManager.score++;
        }
    }
}
