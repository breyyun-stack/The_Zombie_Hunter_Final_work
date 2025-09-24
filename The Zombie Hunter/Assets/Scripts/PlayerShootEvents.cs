using UnityEngine;

public static class PlayerShootEvents
{
    public static event System.Action OnShoot;

    public static void InvokeShoot()
    {
        OnShoot?.Invoke();
    }
}
