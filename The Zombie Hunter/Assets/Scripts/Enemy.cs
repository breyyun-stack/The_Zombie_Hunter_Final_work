using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ObjectPool myPool; // Сюда Unity сама подставит пул при добавлении префаба в пул

    public void Die()
    {
        // Возвращаем себя в пул
        myPool.ReturnToPool(gameObject);
    }
}
