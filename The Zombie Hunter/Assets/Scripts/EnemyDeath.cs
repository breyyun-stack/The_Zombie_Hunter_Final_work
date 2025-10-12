using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;
    private Collider colliderEnemy;
    private Rigidbody rb;
    private StateController stateController;

    private void OnEnable()
    {
        EnemyHitEvents.OnHit += Death;
    }

    private void OnDisable()
    {
        EnemyHitEvents.OnHit -= Death;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        colliderEnemy = GetComponent<Collider>();
        stateController = GetComponent<StateController>();
    }

    private void Death(int health)
    {
        if (health <= 0)
        {
            animator.SetTrigger("isDeath");

            rb.isKinematic = true;

            stateController.enabled = false;

            colliderEnemy.enabled = false;

            //animator.enabled = false;
        }
    }
}
