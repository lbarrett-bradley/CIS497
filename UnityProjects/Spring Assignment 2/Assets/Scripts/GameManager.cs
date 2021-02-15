/*
 * Liam Barrett
 * GameManager.cs
 * Spring Assignment 2
 * Manages overall game function; win and loss conditions, startup, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public WinZone winZone;
    public GameObject player;
    public Guard guard;
    public GuardListener guardListener;
    public SecurityCam securityCam;
    public Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        winZone = GameObject.FindGameObjectWithTag("WinZone").GetComponent<WinZone>();
        gameOverText.text = "";
        guard = GameObject.FindGameObjectWithTag("Guard").GetComponent<Guard>();
        guardListener = new GuardListener();
        securityCam = new SecurityCam();
        securityCam.guards.Add(guardListener);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (guard.caughtPlayer)
        {
            Time.timeScale = 0;
            gameOverText.text = "You Got Caught!\nPress 'R' to Restart";

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Stealth");
            }
        }

        if (winZone.touchPlayer)
        {
            Time.timeScale = 0;
            gameOverText.text = "You Made it to the Goal!\nPress 'R' to Restart";

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Stealth");
            }
        }
    }
}
