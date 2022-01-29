using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float moveSpeed = 2;

    [Range(0, 1)]
    [SerializeField]
    private float damage = .25f;

    private Rigidbody2D _rigidbody;

    public Transform TargetingPlayer { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        TargetingPlayer = Random.Range(0, 2) == 0 ? Player.leftPlayer : Player.rightPlayer;

        //temporary until I get artwork
        Transform otherPlayer = TargetingPlayer == Player.leftPlayer ? Player.rightPlayer : Player.leftPlayer;
        GetComponentInChildren<SpriteRenderer>().color = otherPlayer.GetComponentInChildren<SpriteRenderer>().color;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = (TargetingPlayer.position - transform.position).normalized * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shot shot = collision.attachedRigidbody.GetComponent<Shot>();
        if (shot && shot.PlayerShotFrom == TargetingPlayer)
        {
            Destroy(gameObject);
        }

        Player player = collision.attachedRigidbody.GetComponent<Player>();
        if (player && player.transform == TargetingPlayer)
        {
            player.GetComponent<PlayerHealth>().Damage(damage);
            Destroy(gameObject);
        }
    }

}