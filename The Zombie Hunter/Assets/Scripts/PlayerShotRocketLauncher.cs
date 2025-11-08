using UnityEngine;
using VContainer;
using static WeaponSO;

public class PlayerShotRocketLauncher : MonoBehaviour
{
    private WeaponManagerSO _weaponManagerSO;
    private ObjectPool _objectPoolForRocketLauncher;

    [Inject]
    public void Construct(WeaponManagerSO weaponManager, ObjectPool objectPool)
    {
        _weaponManagerSO = weaponManager;
        _objectPoolForRocketLauncher = objectPool;
    }

    private RaycastHit hit;
    private Vector3 directionShot;
    
    private void OnEnable()
    {
        PlayerShootEvents.OnShoot += Shoot;
    }

    private void OnDisable()
    {
        PlayerShootEvents.OnShoot -= Shoot;
    }

    /// <summary>
    /// Выстрел из базуки
    /// </summary>
    public void Shoot()
    {
        
        var indexWeapon = _weaponManagerSO.IndexWeapon;

        var muzzle = _weaponManagerSO.FirePoint;
        var weapon = _weaponManagerSO.GetWeapon(indexWeapon);

        if (weapon == null || muzzle == null)
        {
            return;
        }

        if (weapon.weaponType != WeaponType.RocketLauncher) return;

        // Берем начальные координаты выстрела и убираем координату y, чтобы выстрел был ровный
        directionShot = -muzzle.right;
        directionShot.y = 0;
        directionShot.Normalize();

        // Достаем из пул снаряд и поворачиваем его правильно
        var missile = _objectPoolForRocketLauncher.GetPool(muzzle.position, Quaternion.LookRotation(directionShot, muzzle.up));

        var rb = missile.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(directionShot * weapon.shotPower, ForceMode.Impulse);
    }
}
