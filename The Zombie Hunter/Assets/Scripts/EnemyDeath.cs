using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    private Collider colliderEnemy;
    private Rigidbody rb;
    private StateController stateController;

    public ObjectPool MyPool { get; set; }
    public SpawnerEnemy SpawnerEnemy { get; set; }

    private bool _firstFrameAfterEnable = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        colliderEnemy = GetComponent<Collider>();
        stateController = GetComponent<StateController>();
    }

    /// <summary>
    /// —мерть врага перед возвращением в пул
    /// </summary>
    /// <param name="health"></param>
    public void Death(int health)
    {
        if (health <= 0)
        {
            rb.isKinematic = true;

            animator.SetTrigger("isDeath");

            stateController.enabled = false;
            colliderEnemy.enabled = false;

            LootFactory.Spawn(LootType.Coin, transform.position + Vector3.up * 1f, Quaternion.identity);

            Invoke("ReturnPool", 1.5f);
        }
    }

    /// <summary>
    /// ¬озвращение в пул и восстановление дл€ применени€
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
