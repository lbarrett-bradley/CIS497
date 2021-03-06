﻿/*
* Liam Barrett
* Assignment 1
* Code to have camera follow player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
