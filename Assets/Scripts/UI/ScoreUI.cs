using UnityEngine;

public sealed class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text scoreText;

	public void HandleScore(int score) 
        => scoreText.text = $"Score: {score}";
}
