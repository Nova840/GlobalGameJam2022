using System.Collections;
using UnityEngine;

public sealed class Shot : MonoBehaviour
{
    [Min(0)]
    [SerializeField]
    private float destroyTime = 10;

    [SerializeField]
    private GameObject hitEfect;

    private float speed;
    private int damage;

    public Transform ShotFrom { get; private set; }
    private Enemy enemyShotFrom;

    private IEnumerator Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        if (destroyTime > 0)
		{
			yield return new WaitForSeconds(destroyTime);
		}

		Destroy(gameObject);
    }

    public void Initialize(Transform shotFrom, float speed, int damage)
    {
        ShotFrom = shotFrom;
        enemyShotFrom = shotFrom.GetComponent<Enemy>();//can be null
        this.speed = speed;
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.attachedRigidbody.TryGetComponent(out Enemy enemy)
            && enemy.TargetingPlayer == ShotFrom)
        {
            HandleHit(collider);
        }
        if (enemyShotFrom && collider.CompareTag("PlayerHitTrigger")
            && collider.attachedRigidbody.TryGetComponent(out Player player)
            && enemyShotFrom.TargetingPlayer == player.transform)
        {
            HandleHit(collider);
        }
    }

    private void HandleHit(Collider2D collider)
    {
        if (collider.attachedRigidbody.TryGetComponent(out Health health))
        {
            health.Damage(damage);
        }
        DestroyAndDetachParticles();

        Instantiate(hitEfect, collider.ClosestPoint(transform.position), Quaternion.identity);
    }

    private void DestroyAndDetachParticles()
    {
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            Destroy(ps.gameObject, destroyTime);
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            ps.transform.SetParent(null, true);
            ps.transform.localScale = Vector3.one;
        }
        Destroy(gameObject);
    }
}