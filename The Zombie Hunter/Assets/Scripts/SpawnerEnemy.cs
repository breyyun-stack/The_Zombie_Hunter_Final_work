using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private int initialPoolSize = 5;

    private int currentPoolSize;

    private void Start()
    {
        currentPoolSize = 0;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (currentPoolSize < initialPoolSize)
        {
            // Берём врага из пула
            GameObject newEnemy = enemyPool.GetPool(spawnPoint.position, Quaternion.identity);

            if (newEnemy == null) return;

            // Говорим врагу: "Твой пул — вот он!"
            newEnemy.GetComponent<Enemy>().myPool = enemyPool;

            currentPoolSize++;
        }
    }
}
