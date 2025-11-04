using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponSO/Weapon Manager", order = 0)]
public class WeaponManagerSO : ScriptableObject
{
    [SerializeField] private List<WeaponSO> weapons = new List<WeaponSO>();

    public int IndexWeapon { get; set; }

    public Transform FirePoint {  get; set; }

    public int WeaponCount => weapons.Count;

    /// <summary>
    /// Получить оружие по индексу
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public WeaponSO GetWeapon(int index)
    {
        if (index >= 0 && index < weapons.Count)
            return weapons[index];
        else
        {
            Debug.LogError($"Weapon index {index} out of range!");
            return null;
        }
    }
}
