using UnityEngine;

public class CurrentWeaponInUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponsUI;

    private void OnEnable()
    {
        PlayerWeaponEvents.OnWeaponChanged += WeaponSelect;
    }

    private void OnDisable()
    {
        PlayerWeaponEvents.OnWeaponChanged -= WeaponSelect;
    }

    private void Awake()
    {
        RemoveAllSelections();
    }

    /// <summary>
    /// Выделение активного оружия
    /// </summary>
    /// <param name="indexWeapon"></param>
    public void WeaponSelect(int indexWeapon)
    {
        RemoveAllSelections();

        _weaponsUI[indexWeapon].SetActive(true);
    }

    /// <summary>
    /// Сброс выделения всего оружия
    /// </summary>
    public void RemoveAllSelections()
    {
        foreach (var weapon in _weaponsUI)
        {
            weapon.SetActive(false);
        }
    }
}
