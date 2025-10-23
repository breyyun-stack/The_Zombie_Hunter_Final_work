using UnityEngine;

public class EnemyHealth : MonoBehaviour, IEnemyHealth
{
    [SerializeField] private int maxHealth = 100;

    private EnemyDeath _enemyDeath;

    private EnemyHit _enemyHit;

    private int currentHealth;

    void Start()
    {
        _enemyDeath = GetComponent<EnemyDeath>();

        _enemyHit = GetComponent<EnemyHit>();

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

        _enemyDeath.Death(currentHealth);

        _enemyHit.HitEnemy();

        //EnemyHitEvents.EnemyHit(currentHealth);

        Debug.Log($"Жизней осталось: {currentHealth}");
    }
}
