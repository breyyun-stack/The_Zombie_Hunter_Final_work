using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth, IPoolable
{
    [SerializeField] int maxHealth = 100;

    public ObjectPool MyPool { get; set; }

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        currentHealth = Mathf.Max(currentHealth, 0);

        //if (currentHealth <= 0)
        //{
        //    currentHealth = 0;
        //}

        PlayerHitEvents.PlayerHit(currentHealth);

        Debug.Log($"Жизней осталось: {currentHealth}");
    }

    public void Heal(int heal)
    {
        currentHealth += heal;

        currentHealth = Mathf.Min(currentHealth, maxHealth);

        Debug.Log($"+ {heal} к жизни. Теперь жизней {currentHealth}");
    }
}
