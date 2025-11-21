using UnityEngine;

public class EnemyDeath : MonoBehaviour, IPoolable, ISpawnerEnemy
{
    [Header("Точка спавна лута")]
    [SerializeField] private Transform _lootSpawnPoint;

    private Animator animator;
    private Collider colliderEnemy;
    private Rigidbody rb;
    private StateController stateController;

    public ObjectPool MyPool { get; set; }
    public SpawnerEnemy SpawnerEnemy { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        colliderEnemy = GetComponent<Collider>();
        stateController = GetComponent<StateController>();
    }

    /// <summary>
    /// Смерть врага перед возвращением в пул
    /// </summary>
    /// <param name="health"></param>
    public void Death(int health)
    {
        if (health <= 0)
        {
            LootFactory.Spawn(LootType.Coin, _lootSpawnPoint.position, Quaternion.identity);
            LootFactory.Spawn(LootType.Health, _lootSpawnPoint.position, Quaternion.identity);

            rb.isKinematic = true;

            animator.SetTrigger("isDeath");

            stateController.enabled = false;
            colliderEnemy.enabled = false;

            Invoke("ReturnPool", 1.5f);
        }
    }

    /// <summary>
    /// Возвращение в пул и восстановление для применения
    /// </summary>
    private void ReturnPool()
    {
        SpawnerEnemy.TheNumberOfEnemiesKilled();

        rb.isKinematic = false;
        stateController.enabled = true;
        colliderEnemy.enabled = true;

        MyPool.ReturnToPool(gameObject);
    }
}
