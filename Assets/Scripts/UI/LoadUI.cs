using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LoadUI : MonoBehaviour
{
    [SerializeField]
    private string hudScene = "Hud";

	private void Awake()
        => SceneManager.LoadScene(hudScene, LoadSceneMode.Additive);
}
