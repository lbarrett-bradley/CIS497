﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnterTrigger : MonoBehaviour
{
    public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            textbox.text = "You Win!";
        }
    }
}
