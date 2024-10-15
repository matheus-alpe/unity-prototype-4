using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private readonly float spawnRange = 9;
    public int waveNumber = 0;
    public int EnemyCount
    {
        get => FindObjectsOfType<Enemy>().Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerup), 3, 10);
    }

    private void Update()
    {
        if (EnemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private void SpawnEnemyWave(int enemyQuantity)
    {
        for (int i = 0; i < enemyQuantity; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float spawnPosX = GenerateRandomSpawnValue();
        float spawnPosZ = GenerateRandomSpawnValue();

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    private float GenerateRandomSpawnValue() => Random.Range(-spawnRange, spawnRange);
}
