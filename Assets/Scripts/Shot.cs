using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float destroyTime = 10;

    private float speed;
    private int damage;

    public Transform ShotFrom { get; private set; }
    private Enemy enemyShotFrom;

    private IEnumerator Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        if (destroyTime > 0)
            yield return new WaitForSeconds(destroyTime);
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
        if (collider.attachedRigidbody.TryGetComponent(out Enemy enemy) && enemy.TargetingPlayer == ShotFrom)
        {
            enemy.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
        if (enemyShotFrom && collider.CompareTag("PlayerHitTrigger") && collider.attachedRigidbody.TryGetComponent(out Player player) && enemyShotFrom.TargetingPlayer == player.transform)
        {
            player.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
    }

}