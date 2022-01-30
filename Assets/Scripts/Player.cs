using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField]
    private bool isLeftPlayer = true;
    public bool IsLeftPlayer => isLeftPlayer;

    public static Transform LeftPlayer { get; private set; } = null;
    public static Transform RightPlayer { get; private set; } = null;

    private void Awake()
    {
        if (isLeftPlayer)
		{
			LeftPlayer = transform;
		}
		else
		{
			RightPlayer = transform;
		}
	}
}