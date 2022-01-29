using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : Enemy
{

    protected override Vector2 Velocity()
    {
        return Vector2.ClampMagnitude(TargetingPlayer.position - transform.position, 1) * moveSpeed;
    }

}