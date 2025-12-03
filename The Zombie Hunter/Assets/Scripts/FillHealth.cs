using UnityEngine;
using UnityEngine.UI;

public class FillHealth : MonoBehaviour
{
    [SerializeField] private Image _healthCount;

    //[SerializeField] private Text _countHealthText;

    private void OnEnable()
    {
        PlayerHealEvents.OnHeal += FillHealthCount;
        PlayerHitEvents.OnHit += FillHealthCount;
    }

    private void OnDisable()
    {
        PlayerHealEvents.OnHeal -= FillHealthCount;
        PlayerHitEvents.OnHit -= FillHealthCount;
    }

    /// <summary>
    /// Отображение уровня жизни в UI
    /// </summary>
    /// <param name="health"></param>
    public void FillHealthCount(PlayerHealth playerHealth)
    {
        _healthCount.fillAmount = playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }
}
