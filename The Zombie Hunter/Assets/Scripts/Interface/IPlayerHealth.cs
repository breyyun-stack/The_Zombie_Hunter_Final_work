using UnityEngine;

public interface IPlayerHealth
{
    void TakeDamage(float damage);

    void Heal(float heal);
}
