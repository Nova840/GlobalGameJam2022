using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    private bool isLeftPlayer = true;

    private Vector2 shootingInputVector;

    public Vector2 GetMovingInputVector()
    {
        Vector2 v;
        if (isLeftPlayer)
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
        return Input.GetButton(isLeftPlayer ? "Left Shoot" : "Right Shoot");
    }

    public bool GetShootButtonDown()
    {
        return Input.GetButtonDown(isLeftPlayer ? "Left Shoot" : "Right Shoot");
    }

    public bool GetShootButtonUp()
    {
        return Input.GetButtonUp(isLeftPlayer ? "Left Shoot" : "Right Shoot");
    }

}