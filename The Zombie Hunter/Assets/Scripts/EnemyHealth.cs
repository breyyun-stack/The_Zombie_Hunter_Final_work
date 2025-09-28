using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemyHealth
{
    [SerializeField] private int _maxHealth = 100;

    private int currentHealth;

    

    void Start()
    {
        currentHealth = _maxHealth;
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

        Debug.Log($"Жизней осталось: {currentHealth}");
    }
}
