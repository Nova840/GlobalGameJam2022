using UnityEngine;

public sealed class TimeUI : MonoBehaviour
{
    [SerializeField]
	private TMPro.TMP_Text timeText;

    public void HandleTime(float time)
        => timeText.text = $"Time: {Mathf.Floor(time)}";
}