using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerups;

    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 14.0f;
    private float zPowerupRange = 5.0f;
    private float ySpawn = 1f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy ()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int enemyIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[enemyIndex], spawnPos, enemies[enemyIndex].gameObject.transform.rotation);
    }
    void SpawnPowerup ()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);
        int enemyIndex = Random.Range(0, powerups.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerups[enemyIndex], spawnPos, powerups[enemyIndex].gameObject.transform.rotation);
    }
}
