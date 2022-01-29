using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public event Action<int> OnScoreChange;//<new score>

    private int score = 0;
    public int Score
    {
        get => score;
        private set
        {
            score = value;
            OnScoreChange?.Invoke(score);
        }
    }

    private void Awake()
    {
        Enemy.OnEnemyDefeated += OnEnemyDefeated;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDefeated -= OnEnemyDefeated;
    }

    private void OnEnemyDefeated()
    {
        Score++;
    }

}