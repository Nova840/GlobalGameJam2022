using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Min(0)]
    [SerializeField]
    private float moveSpeed = 2;

    private Rigidbody2D _rigidbody;

    private Transform targetingPlayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        targetingPlayer = Random.Range(0, 2) == 0 ? Player.leftPlayer : Player.rightPlayer;

        //temporary until I get artwork
        Transform otherPlayer = targetingPlayer == Player.leftPlayer ? Player.rightPlayer : Player.leftPlayer;
        GetComponentInChildren<SpriteRenderer>().color = otherPlayer.GetComponentInChildren<SpriteRenderer>().color;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = (targetingPlayer.position - transform.position).normalized * moveSpeed;
    }

}