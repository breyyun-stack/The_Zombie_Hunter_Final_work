using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        EnemyHitEvents.OnHit += HitEnemy;
    }

    private void OnDisable()
    {
        EnemyHitEvents.OnHit -= HitEnemy;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HitEnemy(int health) 
    {
        animator.SetTrigger("isHit");
    }
}
