using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int initialPoolSize = 5;
    [SerializeField] private int timeUntilTheNextWave = 3;
    public Action<int> OnTick;

    private GameObject[] trackingPoints;

    private int currentPoolSize;
    private int theNumberOfEnemiesKilled;
    private int currentWave = 0;
    private int waveIncrease = 2;

    private bool IsStartWaveEnemy = true;
    private bool IsReadyWave = true;

    private void Start()
    {
        trackingPoints = GameObject.FindGameObjectsWithTag("TrackingPoint");

        currentPoolSize = 0;
        theNumberOfEnemiesKilled = 0;
    }

    private void Update()
    {
        Debug.Log($"Количество врагов в пуле: {currentPoolSize}");
        Debug.Log($"Количество убитых врагов: {theNumberOfEnemiesKilled}");

        if (IsReadyWave && IsStartWaveEnemy)
        {
            EnemyWave();

            IsReadyWave = false;
            currentWave++;
        }
    }

    /// <summary>
    /// Создание волны
    /// </summary>
    private void EnemyWave()
    {
        for (int i = 0; i < initialPoolSize; i++) 
        {
            SpawnEnemy();
        }
    }

    /// <summary>
    /// Создание врага
    /// </summary>
    void SpawnEnemy()
    {
        var randomNumberPosition = Random.Range(0, trackingPoints.Length);
        var position = trackingPoints[randomNumberPosition].transform.position;

        // Берём врага из пула
        GameObject newEnemy = enemyPool.GetPool(position, Quaternion.identity);

        if (newEnemy == null) return;

        // Даем ссылку врагу на пул для возврата
        newEnemy.GetComponent<EnemyDeath>().MyPool = enemyPool;
        newEnemy.GetComponent<EnemyDeath>().SpawnerEnemy = this;
    }

    /// <summary>
    /// Количество убитых врагов за одну волну
    /// </summary>
    public void TheNumberOfEnemiesKilled()
    {
        theNumberOfEnemiesKilled++;

        if (theNumberOfEnemiesKilled == initialPoolSize)
        {
            IsStartWaveEnemy = true;
            currentPoolSize = 0;
            initialPoolSize += waveIncrease;
            theNumberOfEnemiesKilled = 0;

            StartCountdown();
        }
    }

    /// <summary>
    /// Старт таймера
    /// </summary>
    public void StartCountdown()
    {
        //IsReadyWave = false;
        StartCoroutine(Countdown());
    }

    /// <summary>
    /// Таймер
    /// </summary>
    /// <returns></returns>
    private IEnumerator Countdown()
    {
        int remaining = timeUntilTheNextWave;

        while (remaining > 0)
        {
            OnTick?.Invoke(remaining); // вызов события с текущим временем
            yield return new WaitForSeconds(1f);
            remaining--;
        }

        Debug.Log($"Прошло {timeUntilTheNextWave} секунд");

        OnTick?.Invoke(0); // Последний тик на 0
        IsReadyWave = true;
    }

    /// <summary>
    /// Cброс таймера
    /// </summary>
    public void Reset()
    {
        IsReadyWave = false;
    }
}
