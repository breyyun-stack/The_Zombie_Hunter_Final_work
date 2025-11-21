using UnityEngine;

public class LootMoney : MonoBehaviour, IPoolable
{
    [SerializeField] private int _amount = 1;

    public ObjectPool MyPool { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IPlayerMoney>(out IPlayerMoney playerMoney))
        {
            playerMoney.AddMoney(_amount);

            MyPool.ReturnToPool(gameObject);
        }
    }
}
