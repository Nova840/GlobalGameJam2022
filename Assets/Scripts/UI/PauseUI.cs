using UnityEngine;

public sealed class PauseUI : MonoBehaviour
{
    void Awake()
    {
        PauseManager.OnPauseUpdate += HandlePauseUpdate;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PauseManager.OnPauseUpdate -= HandlePauseUpdate;
    }

    private void HandlePauseUpdate(bool isPaused)
        => gameObject.SetActive(isPaused);

    public void OnBackButtonClick()
        => FindObjectOfType<SceneHandler>().TransitionToEndScreen();

}
