using UnityEngine;
using VContainer;

public class ExplodeMissileRocketLauncher : MonoBehaviour
{
    private WeaponManagerSO _weaponManagerSO;

    [Inject]
    public void Construct(WeaponManagerSO weaponManager)
    {
        _weaponManagerSO = weaponManager;
    }


}
