using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab = default;

    [Min(0)]
    [SerializeField]
    private float spawnDistanceFrom0 = 5;

    [Min(0)]
    [SerializeField]
    private float spawnInterval = 5;

    private IEnumerator Start()
    {
        while (true)
        {
            Instantiate(enemyPrefab, Random.insideUnitCircle.normalized * spawnDistanceFrom0, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}