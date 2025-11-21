using UnityEngine;

public static class LootFactory
{
    public static ObjectPool CoinPool;
    public static ObjectPool HealthPool;

    public static void Initialize(ObjectPool coinPool, ObjectPool healthPool)
    {
        CoinPool = coinPool;
        HealthPool = healthPool;

        if (CoinPool == null) Debug.LogError("CoinPool не назначен!");
        if (HealthPool == null) Debug.LogError("HealthPotionPool не назначен!");
    }

    public static void Spawn(LootType type, Vector3 position, Quaternion rotation = default)
    {
        ObjectPool targetPool = null;

        switch (type)
        {
            case LootType.Coin:
                targetPool = CoinPool;
                break;
            case LootType.Health:
                targetPool = HealthPool;
                break;
            default:
                // Если передали неизвестный тип (например, из-за ошибки в коде)
                Debug.LogWarning("[LootFactory] Предупреждение: неизвестный тип лута '" + type + "'. Пропускаем.");
                return;
        }

        if (targetPool == null)
        {
            Debug.LogWarning($"Нет пула для типа {type}");
            return;
        }

        GameObject loot = targetPool.GetPool(position, rotation);

        //if (loot != null && loot.TryGetComponent<IPoolable>(out IPoolable myPool)) 
        //{
        //    myPool.MyPool = targetPool;
        //}
        //else
        //{
        //    Debug.LogWarning($"Пул для {type} пуст! Рассмотрите IncreaseThePool().");
        //}
    }
}
