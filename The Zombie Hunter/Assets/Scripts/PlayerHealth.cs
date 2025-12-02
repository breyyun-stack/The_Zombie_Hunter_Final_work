using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth, IPoolable
{
    [SerializeField] private float maxHealth = 100;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    public ObjectPool MyPool { get; set; }

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Получение урона
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Max(currentHealth, 0);

        PlayerHitEvents.PlayerHit(this);
    }

    /// <summary>
    /// Восстановление жизней
    /// </summary>
    /// <param name="heal"></param>
    public void Heal(float heal)
    {
        currentHealth += heal;

        currentHealth = Mathf.Min(currentHealth, maxHealth);

        PlayerHealEvents.PlayerHeal(this);
    }
}
