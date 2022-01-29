using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    protected float moveSpeed = 1;

    [Min(0)]
    [SerializeField]
    protected int hitDamage = 25;

    protected Rigidbody2D _rigidbody;

    public Transform TargetingPlayer { get; private set; }

    public static event Action OnEnemyDefeated;

    protected abstract Vector2 Velocity();

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        TargetingPlayer = Random.Range(0, 2) == 0 ? Player.leftPlayer : Player.rightPlayer;

        //temporary until I get artwork
        Transform otherPlayer = TargetingPlayer == Player.leftPlayer ? Player.rightPlayer : Player.leftPlayer;
        GetComponentInChildren<SpriteRenderer>().color = otherPlayer.GetComponentInChildren<SpriteRenderer>().color;
    }

    protected virtual void FixedUpdate()
    {
        _rigidbody.velocity = Velocity();
    }

    protected virtual void OnDestroy()
    {
        OnEnemyDefeated?.Invoke();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.TryGetComponent(out Player player) && player.transform == TargetingPlayer)
        {
            player.GetComponent<Health>().Damage(hitDamage);
            Destroy(gameObject);
        }
    }

}