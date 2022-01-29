using UnityEngine;

public sealed class PlayerAnimator : MonoBehaviour
{
	private void Update()
		=> transform.localPosition = new Vector2(0, Mathf.Sin(Time.time * 2) * 0.05f);
}
