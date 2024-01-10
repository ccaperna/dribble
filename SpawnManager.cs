using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount = 0;
    public int waveNo = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(waveNo);
        Instantiate(powerupPrefab, generateSpawnPos(), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //trova tutti gli ogg della scena identificati con lo script
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNo++;
            spawnEnemyWave(waveNo);
            Instantiate(powerupPrefab, generateSpawnPos(), Quaternion.identity);
        }
    }
    private void spawnEnemyWave(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab, generateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    private Vector3 generateSpawnPos()
    {
        float xSpawn = Random.Range(-spawnRange, spawnRange);
        float zSpawn = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(xSpawn, 0, zSpawn);
        return spawnPos;
    }
}
