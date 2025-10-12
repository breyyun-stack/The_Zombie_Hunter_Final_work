using UnityEngine;

public static class PlayerHitEvents
{
    public static event System.Action<int> OnHit;

    public static void PlayerHit(int hit)
    {
        OnHit?.Invoke(hit);
    }
}
