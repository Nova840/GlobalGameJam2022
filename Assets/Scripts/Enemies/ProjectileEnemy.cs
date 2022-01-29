using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : Enemy
{

    [SerializeField]
    private GameObject shotPrefab;

    [Min(0)]
    [SerializeField]
    private float shotSpeed = 3;

    [Min(0)]
    [SerializeField]
    private int shotDamage = 25;

    [Min(0)]
    [SerializeField]
    private float shotInterval = 3;

    [Min(0)]
    [SerializeField]
    private float distanceFromPlayerToStop = 3;

    [Min(0)]
    [SerializeField]
    private float distanceFromPlayerToShoot = 4;

    protected override Vector2 Velocity()
    {
        Vector3 targetPos = TargetingPlayer.position + (transform.position - TargetingPlayer.position).normalized * distanceFromPlayerToStop;
        return Vector2.ClampMagnitude(targetPos - transform.position, 1) * moveSpeed;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (Vector3.Distance(TargetingPlayer.position, transform.position) < distanceFromPlayerToShoot)
            {
                Shot shot = Instantiate(shotPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, TargetingPlayer.position - transform.position)).GetComponent<Shot>();
                shot.Initialize(transform, shotSpeed, shotDamage);
            }
            yield return new WaitForSeconds(shotInterval);
        }
    }

}