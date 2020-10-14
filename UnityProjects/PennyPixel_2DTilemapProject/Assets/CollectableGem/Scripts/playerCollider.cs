using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollider : MonoBehaviour
{
    private ScoreCount scoreManagerScript;

    private void Start()
    {
        scoreManagerScript = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreCount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManagerScript.score++;
    }
}
