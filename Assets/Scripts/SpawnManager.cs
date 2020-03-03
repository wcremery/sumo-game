﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{    
    private float spawnRange = 9.0f;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWaves(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            ++waveNumber;
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
            spawnEnemyWaves(waveNumber);            
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float randomPosX = Random.Range(-spawnRange, spawnRange);
        float randomPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);

        return randomPos;
    }

    private void spawnEnemyWaves(int enemiesToSpawn)
    {
        for(int i=0; i < enemiesToSpawn; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
