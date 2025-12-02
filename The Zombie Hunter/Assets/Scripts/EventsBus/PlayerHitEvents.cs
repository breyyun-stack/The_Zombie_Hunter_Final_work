using UnityEngine;

public static class PlayerHitEvents
{
    public static event System.Action<PlayerHealth> OnHit;

    public static void PlayerHit(PlayerHealth playerHealth)
    {
        OnHit?.Invoke(playerHealth);
    }
}
