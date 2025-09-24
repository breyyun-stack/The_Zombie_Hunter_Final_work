using UnityEngine;

public static class PlayerWeaponEvents
{
    public static event System.Action<int> OnWeaponChanged;

    public static void InvokeWeaponChanged(int weaponIndex)
    {
        OnWeaponChanged?.Invoke(weaponIndex);
    }
}
