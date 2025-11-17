using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private LootType _lootType;
    [SerializeField] private int _amount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPlayerHealth>(out IPlayerHealth playerHealth))
        {
            playerHealth.Heal(_amount);
        }
    }
}
