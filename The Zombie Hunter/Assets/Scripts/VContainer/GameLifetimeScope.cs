using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private WeaponManagerSO _weaponConfig;
    [SerializeField] private ObjectPool _objectPoolForRocketLauncher;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_weaponConfig);
        builder.RegisterInstance(_objectPoolForRocketLauncher);

        // Регистрируем как MonoBehaviour
        builder.RegisterComponentInHierarchy<PlayerWeapon>();
        //builder.RegisterComponentInHierarchy<PlayerShot>();
        builder.RegisterComponentInHierarchy<PlayerShotPistol>();
        builder.RegisterComponentInHierarchy<PlayerShotRifle>();
        builder.RegisterComponentInHierarchy<PlayerShotShotgun>();
        builder.RegisterComponentInHierarchy<PlayerShotRocketLauncher>();
    }
}
