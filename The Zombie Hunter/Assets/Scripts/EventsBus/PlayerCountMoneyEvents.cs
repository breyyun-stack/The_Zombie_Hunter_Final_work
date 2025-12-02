using UnityEngine;

public class PlayerCountMoneyEvents : MonoBehaviour
{
    public static event System.Action<PlayerMoney> OnMoney;

    public static void PlayerCountMoney(PlayerMoney playerMoney)
    {
        OnMoney?.Invoke(playerMoney);
    }
}
