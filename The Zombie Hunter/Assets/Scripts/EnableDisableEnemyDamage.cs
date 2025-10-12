using UnityEngine;

public class EnableDisableEnemyDamage : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        _gameObject.SetActive(false);
    }
    public void EnableEnemyDamage()
    {
        _gameObject.SetActive(true);
    }

    public void DisableEnemyDamage() 
    {
        _gameObject.SetActive(false);
    }
}
