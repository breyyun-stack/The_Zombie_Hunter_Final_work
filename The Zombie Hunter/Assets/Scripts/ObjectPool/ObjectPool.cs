using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private int initialPoolSize = 50;

    private Queue<GameObject> pooledObjects = new Queue<GameObject>();

    private void Start()
    {
        PreloadPool();
    }

    /// <summary>
    /// Создание пула
    /// </summary>
    void PreloadPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(_gameObject, transform);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    /// <summary>
    /// Получить из пула
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public GameObject GetPool(Vector3 position, Quaternion rotation)
    {
        if (pooledObjects.Count == 0) return null;

        GameObject obj = pooledObjects.Dequeue();

        obj.transform.SetPositionAndRotation(position, rotation);

        if (obj.TryGetComponent<IPoolable>(out IPoolable myPool))
        {
            myPool.MyPool = this;
        }

        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Вернуть в пул
    /// </summary>
    /// <param name="obj"></param>
    public void ReturnToPool(GameObject obj)
    {
        if (obj == null) return;

        //obj.transform.position = Vector3.zero;
        //obj.transform.rotation = Quaternion.identity;

        obj.SetActive(false);
        //obj.transform.SetParent(transform); // Опционально: держать в иерархии пула
        pooledObjects.Enqueue(obj);
    }

    /// <summary>
    /// Увеличить пул
    /// </summary>
    /// <param name="poolCount"></param>
    public void IncreaseThePool(int poolCount)
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject obj = Instantiate(_gameObject, transform);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }
}
