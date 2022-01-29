using UnityEngine;

public sealed class PlayAudioThenDestroy : MonoBehaviour
{
    private void Start()
    {
        if (TryGetComponent(out AudioSource audioSource))
        {
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
