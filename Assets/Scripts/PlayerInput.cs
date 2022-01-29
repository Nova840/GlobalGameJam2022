using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    private Player player;

    [Range(0, 1)]
    [SerializeField]
    private float triggerInputThreshold = .5f;

    private Vector2 shootingInputVector;

    private bool leftShootLastFrame, rightShootLastFrame;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public Vector2 GetMovingInputVector()
    {
        Vector2 v;
        if (player.IsLeftPlayer)
            v = new Vector2(Input.GetAxisRaw("Left Movement X"), Input.GetAxisRaw("Left Movement Y"));
        else
            v = new Vector2(Input.GetAxisRaw("Right Movement X"), Input.GetAxisRaw("Right Movement Y"));
        v = Vector2.ClampMagnitude(v, 1);
        return v;
    }

    public Vector2 GetShootingInputVector()
    {
        Vector2 v = GetMovingInputVector();
        if (v != Vector2.zero)
            shootingInputVector = v.normalized;
        return shootingInputVector;
    }

    public bool GetShootButton()
    {
        if (player.IsLeftPlayer)
            return Input.GetAxisRaw("Left Shoot") >= triggerInputThreshold;
        else
            return Input.GetAxisRaw("Right Shoot") >= triggerInputThreshold;
    }

    public bool GetShootButtonDown()
    {
        if (player.IsLeftPlayer)
            return GetShootButton() && GetShootButton() != leftShootLastFrame;
        else
            return GetShootButton() && GetShootButton() != rightShootLastFrame;
    }

    public bool GetShootButtonUp()
    {
        if (player.IsLeftPlayer)
            return !GetShootButton() && GetShootButton() != leftShootLastFrame;
        else
            return !GetShootButton() && GetShootButton() != rightShootLastFrame;
    }

    private void Start()
    {
        SetShooting();
    }

    private void LateUpdate()
    {
        SetShooting();
    }

    private void SetShooting()
    {
        leftShootLastFrame = Input.GetAxisRaw("Left Shoot") >= triggerInputThreshold;
        rightShootLastFrame = Input.GetAxisRaw("Right Shoot") >= triggerInputThreshold;
    }

}