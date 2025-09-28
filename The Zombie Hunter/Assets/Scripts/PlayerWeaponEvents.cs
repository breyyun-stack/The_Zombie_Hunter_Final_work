using UnityEngine;

public static class PlayerWeaponEvents
{
    public static event System.Action<int> OnWeaponChanged;

    /// <summary>
    /// Смена оружия
    /// </summary>
    /// <param name="weaponIndex"></param>
    public static void InvokeWeaponChanged(int weaponIndex)
    {
        OnWeaponChanged?.Invoke(weaponIndex);
    }
}
