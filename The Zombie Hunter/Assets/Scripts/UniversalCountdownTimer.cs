using System;
using System.Collections;
using UnityEngine;

public class UniversalCountdownTimer : MonoBehaviour
{
    [Tooltip("Время обратного отсчёта в секундах")]
    public int duration = 5;

    public Action<int> OnTick;

    // Флаг: таймер завершён?
    //private bool _isReady = false;
    //public bool IsReady => _isReady;
    public bool IsReady { get; private set; } = false;

    //private void Start()
    //{
    //    StartCountdown();
    //}

    /// <summary>
    /// Старт таймера
    /// </summary>
    public void StartCountdown()
    {
        IsReady = false;
        StartCoroutine(Countdown());
    }

    /// <summary>
    /// Таймер
    /// </summary>
    /// <returns></returns>
    private IEnumerator Countdown()
    {
        int remaining = duration;

        while (remaining > 0)
        {
            OnTick?.Invoke(remaining); // вызов события с текущим временем
            yield return new WaitForSeconds(1f);
            remaining--;
        }

        Debug.Log($"Прошло {duration} секунд");

        OnTick?.Invoke(0); // Последний тик на 0
        IsReady = true;

        
    }

    /// <summary>
    /// Cброс таймера
    /// </summary>
    public void Reset()
    {
        IsReady = false;
    }
}
