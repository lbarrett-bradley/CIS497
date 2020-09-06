/*
* Liam Barrett
* Assignment 1
* Causes the player to lose when they fall off the map
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerLoseOnFall : MonoBehaviour
{
    //public Text textbox;

    private void Update()
    {
        if (transform.position.y < -1)
        {
            //textbox.text = "You Lose!";
            ScoreManager.gameOver = true;
        }
    }
}
