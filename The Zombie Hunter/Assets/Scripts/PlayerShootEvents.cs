using UnityEngine;

public static class PlayerShootEvents
{
    public static event System.Action OnShoot;

    /// <summary>
    /// Выстрел
    /// </summary>
    public static void InvokeShoot()
    {
        OnShoot?.Invoke();
    }
}
