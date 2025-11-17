using DG.Tweening.Core.Easing;
using UnityEngine;

public class CoinItem : MonoBehaviour, ILootItem
{
    public int Value = 10;

    public string Name => "Монета";

    public void ApplyEffect()
    {
        // Например, добавить к глобальному счёту игрока
        //GameManager.Instance.AddCoins(Value);
        Debug.Log($"+{Value} монет!");
    }
}
