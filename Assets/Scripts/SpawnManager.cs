using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] powerupPrefab;

    private float spawnRange = 9f;
    private int enemiesPerWave = 1;
    private int enemiesInScene;

    private void Start()
    {
        SpawnEnemyWave(enemiesPerWave);
    }

    private Vector3 RandomSpawnPosition()
    {
        float randX = Random.Range(-spawnRange, spawnRange);
        float randZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randX, 0, randZ);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        int randomIndex = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[randomIndex], RandomSpawnPosition(), Quaternion.identity);
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, RandomSpawnPosition(), Quaternion.identity);
        }
    }

    private void Update()
    {
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        if(enemiesInScene<= 0)
        {
            enemiesPerWave++;
            SpawnEnemyWave(enemiesPerWave);
        }
    }
}
