using UnityEngine;

public class CallingShootingEvent : MonoBehaviour
{
    public void ShootingEvent()
    {
        PlayerShootEvents.InvokeShoot();
    }
}
