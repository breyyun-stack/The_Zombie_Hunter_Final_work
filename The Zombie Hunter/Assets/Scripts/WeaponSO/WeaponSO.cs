using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponSO/Create Weapon", order = 0)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private RuntimeAnimatorController _overrideController;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private int _fireRange;
    [SerializeField] private int _damage;
    [SerializeField] private float _speedAnimation;
}
