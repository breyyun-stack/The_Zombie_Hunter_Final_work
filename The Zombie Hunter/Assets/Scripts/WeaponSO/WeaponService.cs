using System;
using UnityEngine;

public class WeaponService : IWeaponService
{
    private WeaponSO _currentWeapon;
    private int _currentIndex;
    private Transform _currentFirePoint;

    public WeaponSO CurrentWeapon => _currentWeapon;
    public int CurrentWeaponIndex => _currentIndex;
    public Transform CurrentFirePoint => _currentFirePoint;

    public event Action<WeaponSO> OnWeaponChanged;

    public void SetWeapon(WeaponSO weapon, int index, Transform muzzlePoint)
    {
        _currentWeapon = weapon;
        _currentIndex = index;
        _currentFirePoint = muzzlePoint;
        OnWeaponChanged?.Invoke(weapon);
    }
}
