using UnityEngine;

public sealed class PlayMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    private void Start()
        => MusicManager.Instance.PlayMusic(audioClip);
}
