using UnityEngine;
using VContainer;
using static WeaponSO;

public class PlayerShot : MonoBehaviour
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

        // Берем начальные координаты выстрела и убираем координату y, чтобы выстрел был ровный
        directionShot = -muzzle.right;
        directionShot.y = 0;
        directionShot.Normalize();

        switch (weapon.weaponType)
        {
            case WeaponType.Pistol:
                ShootPistolAndRifle(muzzle.position, directionShot, weapon);
                break;
            case WeaponType.Rifle:
                ShootPistolAndRifle(muzzle.position, directionShot, weapon);
                break;
            case WeaponType.Shotgun:
                ShootShotgun(muzzle.position, directionShot, weapon);
                break;
            case WeaponType.RocketLauncher:
                ShootRocketLauncher(muzzle.position, directionShot, weapon);
                break;
            default:
                ShootKnife(weapon);
                break;
        }
    }


    public void ShootKnife(WeaponSO weapon)
    {

    }

    /// <summary>
    /// Выстрел из пистолета и автомата
    /// </summary>
    /// <param name="muzzle"></param>
    /// <param name="direction"></param>
    /// <param name="weapon"></param>
    public void ShootPistolAndRifle(Vector3 muzzle, Vector3 direction, WeaponSO weapon)
    {
        bool shoot = Physics.Raycast(muzzle, direction, out hit, weapon._fireRange);

        if (shoot)
        {
            Debug.DrawRay(muzzle, direction * weapon._fireRange, Color.white, 2f);

            Debug.Log($"Сила выстрела: {weapon._damage}. Расстояние выстрела: {weapon._fireRange}");

            if (hit.collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(weapon._damage);

                Debug.DrawRay(muzzle, direction * weapon._fireRange, Color.red, 2f);
            }
        }
        else
        {
            Debug.DrawRay(muzzle, direction * weapon._fireRange, Color.green, 2f);
        }
    }

    /// <summary>
    /// Выстрел из дробовика
    /// </summary>
    /// <param name="muzzle"></param>
    /// <param name="direction"></param>
    /// <param name="weapon"></param>
    public void ShootShotgun(Vector3 muzzle, Vector3 direction, WeaponSO weapon)
    {
        for (int i = 0; i < weapon.pelletCount; i++)
        {
            // Генерируем случайное отклонение внутри конуса
            Vector3 randomDirection = Random.insideUnitSphere;
            randomDirection = Vector3.RotateTowards(direction, randomDirection, Mathf.Deg2Rad * weapon.spreadAngle, 0f);
            randomDirection = randomDirection.normalized;

            bool shoot = Physics.Raycast(muzzle, direction, out hit, weapon._fireRange);

            if (shoot)
            {
                Debug.DrawRay(muzzle, randomDirection * weapon._fireRange, Color.white, 2f);

                Debug.Log($"Сила выстрела: {weapon._damage}. Расстояние выстрела: {weapon._fireRange}");

                if (hit.collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(weapon._damage);

                    Debug.DrawRay(muzzle, randomDirection * weapon._fireRange, Color.red, 2f);
                }
            }
            else
            {
                Debug.DrawRay(muzzle, randomDirection * weapon._fireRange, Color.green, 2f);
            }
        }
    }

    public void ShootRocketLauncher(Vector3 muzzle, Vector3 direction, WeaponSO weapon)
    {

    }
}
