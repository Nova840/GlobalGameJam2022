using UnityEngine;

public sealed class ChaseEnemy : Enemy
{
	protected override Vector2 Velocity
		=> Vector2.ClampMagnitude(TargetingPlayer.position - transform.position, 1) * moveSpeed;
}