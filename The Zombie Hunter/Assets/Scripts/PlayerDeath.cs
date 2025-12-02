using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private Collider colliderEnemy;
    private Rigidbody rb;
    private PlayerAnimation playerAnimation;
    private PlayerMovement playerMovement;

    private void OnEnable()
    {
        PlayerHitEvents.OnHit += Death;
    }

    private void OnDisable()
    {
        PlayerHitEvents.OnHit -= Death;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        colliderEnemy = GetComponent<Collider>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Death(PlayerHealth playerHealth)
    {
        if (playerHealth.CurrentHealth <= 0)
        {
            animator.SetTrigger("isDeath");

            rb.isKinematic = true;

            colliderEnemy.enabled = false;

            playerAnimation.enabled = false;

            playerMovement.enabled = false;

        }
    }
}
