using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class TransitionToMainMenu : MonoBehaviour
{
	private const string TRANSITION_SCENE = "Transition";

	[SerializeField]
	private SceneHandler sceneHandler;

	public void Start()
		=> Time.timeScale = 0;

	public void LoadLevel()
	{
		var scenesCount = SceneManager.sceneCount;
		for (int i = 0; i < scenesCount; ++i)
		{
			var scene = SceneManager.GetSceneAt(i);

			if (scene.name != TRANSITION_SCENE)
			{
				SceneManager.UnloadSceneAsync(scene);
			}
		}

		sceneHandler.EndScreen();
	}

	public void PlaySound()
	{
		if (TryGetComponent(out AudioSource audioSource))
		{
			audioSource.Play();
		}
	}

	public void TransitionOver()
	{
		Time.timeScale = 1;
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(TRANSITION_SCENE));
	}
}
