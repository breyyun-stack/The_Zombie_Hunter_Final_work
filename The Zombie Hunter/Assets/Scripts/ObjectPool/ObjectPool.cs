using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    [SerializeField] private int initialPoolSize = 50;

    private Queue<GameObject> pooledObjects = new Queue<GameObject>();

    private void Awake()
    {
        PreloadPool();
    }
    void PreloadPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(_gameObject, transform);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    // Получить объект из пула
    public GameObject GetPool(Vector3 position, Quaternion rotation)
    {
        if (pooledObjects.Count == 0) return null;

        GameObject obj;

        obj = pooledObjects.Dequeue();

        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);
        return obj;

        //if (pooledObjects.Count > 0)
        //{
        //    obj = pooledObjects.Dequeue();

        //    obj.transform.SetPositionAndRotation(position, rotation);
        //    obj.SetActive(true);
        //    return obj;
        //}
        //else
        //{
        //    // Опционально: создать новый, если пул исчерпан
        //    //Debug.LogWarning("Пул исчерпан для " + _gameObject.name + ". Создаём новый.");
        //    //obj = Instantiate(_gameObject, transform);

        //    Debug.LogWarning("Пул исчерпан для " + _gameObject.name);

        //    return null;
        //}

        //obj.transform.SetPositionAndRotation(position, rotation);
        //obj.SetActive(true);

    }

    // Вернуть объект в пул
    public void ReturnToPool(GameObject obj)
    {
        if (obj == null) return;

        obj.SetActive(false);
        //obj.transform.SetParent(transform); // Опционально: держать в иерархии пула
        pooledObjects.Enqueue(obj);
    }
}
