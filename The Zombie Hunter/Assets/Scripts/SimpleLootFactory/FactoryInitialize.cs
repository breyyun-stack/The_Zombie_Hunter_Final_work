using UnityEngine;

public class FactoryInitialize : MonoBehaviour
{
    [SerializeField] private ObjectPool coinPool;
    [SerializeField] private ObjectPool healthPool;

    void Awake()
    {
        LootFactory.Initialize(coinPool, healthPool);
    }
}
