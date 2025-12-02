using UnityEngine;
using UnityEngine.UI;

public class CurrentCountMoneyUI : MonoBehaviour
{
    [SerializeField] private Text _currentMoney;

    private void OnEnable()
    {
        PlayerCountMoneyEvents.OnMoney += CurrentMoney;
    }

    private void OnDisable()
    {
        PlayerCountMoneyEvents.OnMoney -= CurrentMoney;
    }

    private void CurrentMoney(PlayerMoney playerMoney)
    {
        _currentMoney.text = playerMoney.CurrentMoney.ToString();
    }
}
