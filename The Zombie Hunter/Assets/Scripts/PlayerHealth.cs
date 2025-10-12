using UnityEngine;

public class PlayerHealth : MonoBehaviour, IPlayerHealth
{
    [SerializeField] int maxHealth = 100;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        PlayerHitEvents.PlayerHit(currentHealth);

        Debug.Log($"Жизней осталось: {currentHealth}");
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
    }
}
