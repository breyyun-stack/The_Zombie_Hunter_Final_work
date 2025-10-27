using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int initialPoolSize = 5;
    [SerializeField] private float timeUntilTheNextWave = 3;

    private GameObject[] trackingPoints;

    private int currentPoolSize;
    private int theNumberOfEnemiesKilled;
    private int currentWave = 0;
    private int waveIncrease = 2;

    private float currentTimeUntilTheNextWave = 0;

    private bool isStartWaveEnemy = false;

    private void Start()
    {
        trackingPoints = GameObject.FindGameObjectsWithTag("TrackingPoint");

        currentPoolSize = 0;
        theNumberOfEnemiesKilled = 0;
        currentTimeUntilTheNextWave = timeUntilTheNextWave;
    }

    private void Update()
    {
        SpawnEnemy();

        Debug.Log($"Количество врагов в пуле: {currentPoolSize}");
        Debug.Log($"Количество убитых врагов: {theNumberOfEnemiesKilled}");

        if (isStartWaveEnemy)
        {
            SpawnEnemy();

            if (currentPoolSize == initialPoolSize) isStartWaveEnemy = false;
        }
    }

    /// <summary>
    /// Создание волны врагов
    /// </summary>
    void SpawnEnemy()
    {
        if (currentPoolSize < initialPoolSize)
        {
            currentWave++;

            var randomNumberPosition = Random.Range(0, trackingPoints.Length);
            var position = trackingPoints[randomNumberPosition].transform.position;

            // Берём врага из пула
            GameObject newEnemy = enemyPool.GetPool(position, Quaternion.identity);

            if (newEnemy == null) return;

            // Говорим врагу: "Твой пул — вот он!"
            newEnemy.GetComponent<EnemyDeath>().MyPool = enemyPool;
            newEnemy.GetComponent<EnemyDeath>().SpawnerEnemy = this;

            currentPoolSize++;
        }
    }

    /// <summary>
    /// Количество убитых врагов за одну волну
    /// </summary>
    public void TheNumberOfEnemiesKilled()
    {
        theNumberOfEnemiesKilled++;

        if (theNumberOfEnemiesKilled == initialPoolSize)
        {
            isStartWaveEnemy = true;
            currentPoolSize = 0;
            initialPoolSize += waveIncrease;
            theNumberOfEnemiesKilled = 0;
        }
    }
}
