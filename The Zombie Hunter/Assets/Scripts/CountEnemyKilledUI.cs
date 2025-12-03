using UnityEngine;
using UnityEngine.UI;

public class CountEnemyKilledUI : MonoBehaviour
{
    [SerializeField] private Text _countEnemy;

    [SerializeField] private SpawnerEnemy _spawnerEnemy;

    private void Update()
    {
        _countEnemy.text = _spawnerEnemy.AllCountEnemiesKilled.ToString();
    }
}
