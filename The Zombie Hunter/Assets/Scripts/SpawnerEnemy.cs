using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;

    [SerializeField] private Transform spawnPoint;

    private void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        // Берём врага из пула
        GameObject newEnemy = enemyPool.GetPool(spawnPoint.position, Quaternion.identity);

        // Говорим врагу: "Твой пул — вот он!"
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.myPool = enemyPool;
    }
}
