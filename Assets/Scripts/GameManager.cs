using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField]
    private Health iceCharacter;
    [SerializeField]
    private Health fireCharacter;
	[SerializeField]
	private SceneHandler sceneHandler;

	private void Awake()
	{
		iceCharacter.OnDeath += HandlePlayerDeath;
		fireCharacter.OnDeath += HandlePlayerDeath;
	}

	private void HandlePlayerDeath() => sceneHandler.EndScreen();
}
