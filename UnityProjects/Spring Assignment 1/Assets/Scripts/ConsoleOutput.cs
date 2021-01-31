/*
 * Liam Barrett
 * ConsoleOutput
 * Spring Assignment 1
 * Tests Enemy subclasses and interfaces
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleOutput : MonoBehaviour
{
    private Enemy[] enemyList = { new RangedEnemy(), new RangedEnemy(), new MeleeEnemy(), new MeleeEnemy(), new HealerEnemy() };
    private Hittable[] hitList = { new RangedEnemy(), new RangedEnemy(), new MeleeEnemy(), new MeleeEnemy(), new HealerEnemy() };

    void Start()
    {
        Enemy melee = new MeleeEnemy();
        Enemy ranged = new RangedEnemy();

        melee.attack();
        ranged.attack();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.attack();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Hittable hittable in hitList)
            {
                hittable.die();
            }
        }
    }
}
