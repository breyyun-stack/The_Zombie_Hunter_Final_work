using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        PlayerHitEvents.OnHit += HitPlayer;
    }

    private void OnDisable()
    {
        PlayerHitEvents.OnHit -= HitPlayer;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HitPlayer(int health)
    {
        animator.SetTrigger("isTakeDamage");
    }
}
