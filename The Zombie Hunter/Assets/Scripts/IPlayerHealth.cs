using UnityEngine;

public interface IPlayerHealth
{
    void TakeDamage(int damage);

    void Heal(int heal);
}
