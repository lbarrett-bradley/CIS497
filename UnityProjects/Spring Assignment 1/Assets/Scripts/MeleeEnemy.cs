/*
 * Liam Barrett
 * MeleeEnemy
 * Spring Assignment 1
 * Concept code for a melee enemy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void attack()
    {
        Debug.Log("Punched Player");
    }
}
