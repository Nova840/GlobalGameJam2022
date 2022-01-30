using UnityEngine;

public sealed class ChaseEnemy : Enemy
{
    protected override Vector2 Velocity
    {
        get
        {
            Vector3 dir = TargetingPlayer.position - transform.position;
            if (dir.magnitude <= .1f)
                return Vector3.zero;
            return dir.normalized * moveSpeed;
        }
    }
}