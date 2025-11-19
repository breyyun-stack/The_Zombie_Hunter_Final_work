using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [Header("Точка спавна лута")]
    [SerializeField] private Transform _lootSpawnPoint;

    private Animator animator;
    private Collider colliderEnemy;
    private Rigidbody rb;
    private StateController stateController;

    public ObjectPool MyPool { get; set; }
    public SpawnerEnemy SpawnerEnemy { get; set; }

    //private bool _firstFrameAfterEnable = false;

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
            var lootPos = _lootSpawnPoint.position;

            //Debug.Log($"position 1: {transform.position}");
            rb.isKinematic = true;

            animator.SetTrigger("isDeath");

            stateController.enabled = false;
            colliderEnemy.enabled = false;

            LootFactory.Spawn(LootType.Coin, lootPos, Quaternion.identity);

            //Debug.Log($"position 2: {transform.position}");

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
