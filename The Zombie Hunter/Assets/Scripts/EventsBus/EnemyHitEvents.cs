using UnityEngine;

public static class EnemyHitEvents
{
    public static event System.Action<int> OnHit;

    public static void EnemyHit(int hit)
    {
        OnHit?.Invoke(hit);
    }
}
