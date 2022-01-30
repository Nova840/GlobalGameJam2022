using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class TransistionToMainMenu : MonoBehaviour
{
	private const string TRANSISTION_SCENE = "Transistion";

	[SerializeField]
	private SceneHandler sceneHandler;

	public void Start()
	{
		Time.timeScale = 0;
	}

	public void LoadLevel()
	{
		var scenesCount = SceneManager.sceneCount;
		for (int i = 0; i < scenesCount; ++i)
		{
			var scene = SceneManager.GetSceneAt(i);

			if (scene.name != TRANSISTION_SCENE)
			{
				SceneManager.UnloadSceneAsync(scene);
			}
		}

		sceneHandler.EndScreen();
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(TRANSISTION_SCENE));
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
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(TRANSISTION_SCENE));
	}
}
