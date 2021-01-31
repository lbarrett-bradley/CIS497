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
