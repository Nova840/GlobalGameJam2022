using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private float acceleration = 5;

    private PlayerInput playerInput;
    private Rigidbody2D _rigidbody;

    private Vector2 velocity = Vector2.zero;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 move = playerInput.GetShootButton() ? Vector2.zero : playerInput.GetMovingInputVector();
        velocity = Vector2.MoveTowards(velocity, move * maxSpeed, acceleration * Time.deltaTime);
        _rigidbody.velocity = velocity;
    }

}