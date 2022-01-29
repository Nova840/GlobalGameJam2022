using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWaves : MonoBehaviour
{
    private int wave = 0;//starts from wave 0

    [SerializeField]
    private Wave[] waves;

    private Wave CurrentWave => waves[Mathf.Min(waves.Length - 1, wave)];

    public event Action<int> OnWaveChange;

    [Serializable]
    public class Wave
    {
        [Min(0)]
        public int numEnemies;
        [Min(0)]
        public float spawnInterval;
    }

    [Min(0)]
    [SerializeField]
    private float betweenWavesDelay;

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [Min(0)]
    [SerializeField]
    private float spawnDistanceFrom0 = 5;

    private int enemiesDefeatedThisWave = 0;

    private void Awake()
    {
        Enemy.OnEnemyDefeated += OnEnemyDefeated;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        OnWaveChange?.Invoke(0);
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDefeated -= OnEnemyDefeated;
    }

    private void OnEnemyDefeated()
    {
        enemiesDefeatedThisWave++;
        if (enemiesDefeatedThisWave >= CurrentWave.numEnemies)
        {
            StartCoroutine(StartNewWave());
        }
    }

    private IEnumerator StartNewWave()
    {
        enemiesDefeatedThisWave = 0;
        wave++;
        OnWaveChange?.Invoke(wave);
        Debug.Log("Wave complete! Entering wave " + wave);
        if (betweenWavesDelay > 0)
            yield return new WaitForSeconds(betweenWavesDelay);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Debug.Log("Spawning " + CurrentWave.numEnemies + " enemies.");
        for (int i = 0; i < CurrentWave.numEnemies; i++)
        {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], Random.insideUnitCircle.normalized * spawnDistanceFrom0, Quaternion.identity);
            if (i < CurrentWave.numEnemies - 1)//skip last element
                yield return new WaitForSeconds(CurrentWave.spawnInterval);
        }
    }

}