using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : MonoBehaviour
{
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winText.enabled = true;
    }
}
