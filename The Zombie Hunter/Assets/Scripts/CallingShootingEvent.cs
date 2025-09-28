using UnityEngine;

public class CallingShootingEvent : MonoBehaviour
{
    /// <summary>
    /// Метод, который вызывает событие о том, что выстрел произошел (Добавляется в анимацию стрельбы).
    /// </summary>
    public void ShootingEvent()
    {
        PlayerShootEvents.InvokeShoot();
    }
}
