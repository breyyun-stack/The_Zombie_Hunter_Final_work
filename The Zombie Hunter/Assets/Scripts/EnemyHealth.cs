using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemyHealth
{
    public int maxHealth = 100;

    private EnemyDeath _enemyDeath;

    private EnemyHit _enemyHit;

    private int currentHealth;

    void Start()
    {
        _enemyDeath = GetComponent<EnemyDeath>();

        _enemyHit = GetComponent<EnemyHit>();

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        _enemyDeath.Death(currentHealth);

        _enemyHit.HitEnemy();
    }
}
