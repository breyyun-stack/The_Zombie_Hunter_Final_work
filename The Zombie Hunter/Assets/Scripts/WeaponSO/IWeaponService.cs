using UnityEngine;

public interface IWeaponService
{
    WeaponSO CurrentWeapon { get; }
    int CurrentWeaponIndex { get; }

    void SetWeapon(WeaponSO weapon, int index, Transform muzzlePoint);
    Transform CurrentFirePoint { get; }

    event System.Action<WeaponSO> OnWeaponChanged;
}
