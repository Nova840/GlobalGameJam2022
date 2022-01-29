using UnityEngine;

public sealed class EndScreen : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text text;

	private void Start() 
        => text.text = $"Score: {ScoreManager.LoadScore()}";
}
