using UnityEngine;

public class AddMoney : MonoBehaviour
{
    [SerializeField] private LootType _lootType;
    [SerializeField] private int _amount = 1;



    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IPlayerMoney>(out IPlayerMoney playerMoney))
        {
            playerMoney.AddMoney(_amount);
        }
    }
}
