using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ObjectPool myPool; // Сюда Unity сама подставит пул (мы назначим в префабе)

    public void Die()
    {
        // Возвращаем себя в пул
        myPool.ReturnToPool(gameObject);
    }
}
