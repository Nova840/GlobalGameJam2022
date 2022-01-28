using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private bool isLeftPlayer = true;
    public bool IsLeftPlayer => isLeftPlayer;

    public static Transform leftPlayer { get; private set; } = null;
    public static Transform rightPlayer { get; private set; } = null;

    private void Awake()
    {
        if (isLeftPlayer)
            leftPlayer = transform;
        else
            rightPlayer = transform;
    }

}