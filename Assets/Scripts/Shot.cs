using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float speed = 10;

    [Min(0)]
    [SerializeField]
    private float destroyTime = 10;

    public Transform PlayerShotFrom { get; private set; }

    private IEnumerator Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        if (destroyTime > 0)
            yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    public void Initialize(Transform playerShotFrom)
    {
        PlayerShotFrom = playerShotFrom;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.attachedRigidbody.GetComponent<Enemy>();
        if (enemy && enemy.TargetingPlayer == PlayerShotFrom)
        {
            Destroy(gameObject);
        }
    }

}