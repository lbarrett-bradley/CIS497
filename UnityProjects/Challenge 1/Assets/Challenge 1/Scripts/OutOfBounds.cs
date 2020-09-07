using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 80 || transform.position.y <= -51)
        {
            ScoreManager.gameOver = true;
        }
    }
}
