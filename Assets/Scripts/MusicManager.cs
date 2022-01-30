using UnityEngine;

public sealed class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
	{
        get
		{
            if (instance == null)
			{
                instance = FindObjectOfType<MusicManager>();

                if (instance == null)
				{
					instance = new GameObject("Music Manager").AddComponent<MusicManager>();
				}
			}
            return instance;
        }
	}

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip audioClip)
	{
        if (audioSource.clip != audioClip)
		{
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
		}
	}
}
