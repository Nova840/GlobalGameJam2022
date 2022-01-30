using UnityEngine;

public sealed class Sounds : MonoBehaviour
{
	[SerializeField] private AudioClip buttonSound;

	public void PlayButtonSound() 
		=> SoundManager.Instance.PlaySound(buttonSound);
}
