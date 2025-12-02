using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPlayerHealth>(out IPlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
