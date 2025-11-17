using UnityEngine;
using VContainer;
using static WeaponSO;

public class PlayerShotRifle : MonoBehaviour
{
    private WeaponManagerSO _weaponManagerSO;

    [Inject]
    public void Construct(WeaponManagerSO weaponManager)
    {
        _weaponManagerSO = weaponManager;
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
    /// Выстрел
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

        if (weapon.weaponType != WeaponType.Rifle) return;

        // Берем начальные координаты выстрела и убираем координату y, чтобы выстрел был ровный
        directionShot = -muzzle.right;
        directionShot.y = 0;
        directionShot.Normalize();

        bool shoot = Physics.Raycast(muzzle.position, directionShot, out hit, weapon.fireRange);

        if (shoot)
        {
            Debug.DrawRay(muzzle.position, directionShot * weapon.fireRange, Color.white, 2f);

            Debug.Log($"Сила выстрела: {weapon.damage}. Расстояние выстрела: {weapon.fireRange}");

            if (hit.collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(weapon.damage);

                Debug.DrawRay(muzzle.position, directionShot * weapon.fireRange, Color.red, 2f);
            }
        }
        else
        {
            Debug.DrawRay(muzzle.position, directionShot * weapon.fireRange, Color.green, 2f);
        }
    }
}
