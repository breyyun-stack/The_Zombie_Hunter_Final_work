using UnityEngine;

public class PlayerMoney : MonoBehaviour, IPlayerMoney
{
    private int currentMoney = 0;

    public int Money {  get { return currentMoney; } }

    public void AddMoney(int amount)
    {
        currentMoney += amount;

        Debug.Log($"Количество денег: {currentMoney}");
    }
}
