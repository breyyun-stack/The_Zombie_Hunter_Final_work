using UnityEngine;

public class PlayerHealEvents : MonoBehaviour
{
    public static event System.Action<PlayerHealth> OnHeal;

    public static void PlayerHeal(PlayerHealth playerHealth)
    {
        OnHeal?.Invoke(playerHealth);
    }
}
