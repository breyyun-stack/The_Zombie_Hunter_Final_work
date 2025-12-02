using UnityEngine;

public class PlayerMoney : MonoBehaviour, IPlayerMoney
{
    private int currentMoney = 0;

    public int CurrentMoney => currentMoney;

    public int Money {  get { return currentMoney; } }

    private void Start()
    {
        PlayerCountMoneyEvents.PlayerCountMoney(this);
    }
    public void AddMoney(int amount)
    {
        currentMoney += amount;

        Debug.Log($"Количество денег: {currentMoney}");

        PlayerCountMoneyEvents.PlayerCountMoney(this);
    }
}
