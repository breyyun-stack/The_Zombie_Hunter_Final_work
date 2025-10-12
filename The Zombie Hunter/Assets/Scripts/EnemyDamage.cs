using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPlayerHealth>(out IPlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
