using UnityEngine;

public sealed class PlayerAnimator : MonoBehaviour
{
	[SerializeField]
	private float speed = 1.5f;
	[SerializeField]
	private float distance = 0.025f;

	private void Update()
		=> transform.localPosition = new Vector3(0, Mathf.Sin(Time.time * speed) * distance, transform.localPosition.z);
}
