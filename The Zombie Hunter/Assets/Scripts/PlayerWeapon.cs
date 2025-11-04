using UnityEngine;
using VContainer;

public class PlayerWeapon : MonoBehaviour
{
    private WeaponManagerSO _weaponManagerSO;

    [Inject]
    public void Construct(WeaponManagerSO weaponManager)
    {
        _weaponManagerSO = weaponManager;
    }

    [SerializeField] private Transform[] _firePoints;

    [SerializeField] private int _startWeaponIndex = 0;

    [SerializeField] private GameObject[] _weaponViews; // дочерние оружия на сцене

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        ChangeWeapon(_startWeaponIndex);
    }

    void Start()
    {
        Debug.Log($"Количество оружия: {_weaponManagerSO.WeaponCount}");
    }

    private void OnEnable()
    {
        PlayerWeaponEvents.OnWeaponChanged += ChangeWeapon;
    }

    private void OnDisable()
    {
        PlayerWeaponEvents.OnWeaponChanged -= ChangeWeapon;
    }

    /// <summary>
    /// Сброс всего оружия
    /// </summary>
    public void ResetAllWeapons()
    {
        foreach (var weapon in _weaponViews) 
        {
            weapon.SetActive(false);
        }
    }

    /// <summary>
    /// Смена оружия
    /// </summary>
    /// <param name="numberWeapon"></param>
    public void ChangeWeapon(int numberWeapon) 
    {
        _weaponManagerSO.IndexWeapon = numberWeapon;
        _weaponManagerSO.FirePoint = _firePoints[numberWeapon];

        var weapon = _weaponManagerSO.GetWeapon(numberWeapon);
        if (weapon == null) return;

        ResetAllWeapons();

        animator.runtimeAnimatorController = weapon._overrideController;

        _weaponViews[numberWeapon].SetActive(true);
    }
}
