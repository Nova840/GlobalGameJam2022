using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class TransitionScene : MonoBehaviour
{
	private const string TRANSITION_SCENE = "Transition";

	[SerializeField]
	private SceneHandler sceneHandler;

	public static string NextSceneName { get; private set; }

	public static void TransitionToScene(string sceneName)
	{
		if (!SceneManager.GetSceneByName(TRANSITION_SCENE).IsValid())
		{
			NextSceneName = sceneName;
			SceneManager.LoadScene(TRANSITION_SCENE, LoadSceneMode.Additive);
		}
	}

	public void Start()
		=> Time.timeScale = 0;

	public void LoadLevel()
	{
		UnloadPreviousScene();

		SceneManager.LoadScene(NextSceneName, LoadSceneMode.Additive);
	}

	private static void UnloadPreviousScene()
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
