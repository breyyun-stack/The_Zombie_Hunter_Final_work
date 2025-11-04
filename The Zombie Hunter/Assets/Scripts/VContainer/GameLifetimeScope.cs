using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private WeaponManagerSO _weaponConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        // Регистрируем ScriptableObject как синглтон (один экземпляр на весь scope)
        builder.Register<WeaponService>(Lifetime.Singleton).As<IWeaponService>();

        // Регистрируем ScriptableObject как синглтон (один экземпляр на весь scope)
        builder.RegisterInstance(_weaponConfig);

        // Регистрируем как MonoBehaviour
        builder.RegisterComponentInHierarchy<PlayerWeapon>();
        builder.RegisterComponentInHierarchy<PlayerShot>();
    }
}
