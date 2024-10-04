using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private int numberOfWorkersToSpawn;
    private float _nextSpawnTime;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + timeBetweenSpawns;
            Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);
            numberOfWorkersToSpawn--;

            if (numberOfWorkersToSpawn <= 0) Destroy(gameObject);
        }
    }
}
