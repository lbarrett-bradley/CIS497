using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Hazard, Hittable
{
    public void hitPlayer()
    {
        Debug.Log("Hit player and decreased player health");
    }

    public void die()
    {
        Debug.Log("Was killed by player, played death animation, and deleted Enemy instance");
    }

    public abstract void attack();
}
