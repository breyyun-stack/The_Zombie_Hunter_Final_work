using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponSO/Create Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    public enum WeaponType
    {
        Knife,
        Pistol,
        Rifle,
        Shotgun,
        RocketLauncher
    }

    public RuntimeAnimatorController _overrideController;
    public int _fireRange;
    public int _damage;
    public float _speedAnimation;
    public WeaponType weaponType;

    [Header("Параметры дробовика")]
    public int pelletCount = 8;        // Количество дробинок
    public float spreadAngle = 10f;    // Угол разброса в градусах

    [Header("Параметры базуки")]
    public GameObject prefabRocketLauncher;
    public float shotPower = 10f;
    public float explosionRadius = 3f;
}
