using UnityEngine;

public sealed class WaveUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text text;

	public void HandleWave(int wave) => text.text = $"Wave\n{wave}";
}
