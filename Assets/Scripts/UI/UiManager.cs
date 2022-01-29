using UnityEngine;

public sealed class UiManager : MonoBehaviour
{
	[SerializeField]
	private PlayerHealthUI iceHealthUI;
	[SerializeField]
	private PlayerHealthUI fireHealthUI;
	[SerializeField]
	private ScoreUI scoreUI;
	[SerializeField]
	private TimeUI timeUI;
	[SerializeField]
	private WaveUI waveUI;

	private void Awake()
	{
		var players = FindObjectsOfType<Player>();

		foreach (var player in players)
		{
			if (player.TryGetComponent(out Health playerHealth))
			{
				playerHealth.OnHealthChange += player.IsLeftPlayer ? iceHealthUI.SetHeath : fireHealthUI.SetHeath;
			}
		}

		var scoreManager = FindObjectOfType<ScoreManager>();

		if (scoreManager)
		{
			scoreManager.OnScoreChange += scoreUI.HandleScore;
		}

		var waveManager = FindObjectOfType<EnemyWaves>();

		if (waveManager)
		{
			waveManager.OnWaveChange += waveUI.HandleWave;
		}
	}

	private void Update() 
		=> timeUI.HandleTime(Time.timeSinceLevelLoad);
}
