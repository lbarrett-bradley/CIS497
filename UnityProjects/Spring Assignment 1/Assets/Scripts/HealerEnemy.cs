using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerEnemy : Enemy, Hittable, Hazard
{
    public override void attack()
    {
        Debug.Log("Heals nearby Enemies");
    }
}
