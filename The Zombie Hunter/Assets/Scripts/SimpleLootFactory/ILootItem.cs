using UnityEngine;

public interface ILootItem
{
    string Name { get; }

    void ApplyEffect();
}
