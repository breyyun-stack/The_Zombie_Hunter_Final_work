using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController[] _animatorOverride;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private int _startWeaponIndex = 0;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        ChangeWeapon(_startWeaponIndex);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
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
        foreach (var weapon in _weapons)
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
        ResetAllWeapons();

        animator.runtimeAnimatorController = _animatorOverride[numberWeapon];
        _weapons[numberWeapon].SetActive(true);
    }
}
