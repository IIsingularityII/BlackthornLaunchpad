using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private float timeBetweenSpawns;
    private float _nextSpawnTime;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomPosition.position, Quaternion.identity);
        }
    }
}
