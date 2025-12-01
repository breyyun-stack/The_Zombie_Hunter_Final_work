using System.Collections;
using UnityEngine;

public class LootMoney : MonoBehaviour, IPoolable
{
    [SerializeField] private int _amount = 1;
    [SerializeField] private float _timeUntilReturn = 5f;

    public ObjectPool MyPool { get; set; }

    private void OnEnable()
    {
        StartCoroutine(ReturnAfterDelay(_timeUntilReturn));
    }

    private void OnDisable()
    {
        StopCoroutine(ReturnAfterDelay(_timeUntilReturn));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IPlayerMoney>(out IPlayerMoney playerMoney))
        {
            playerMoney.AddMoney(_amount);

            MyPool.ReturnToPool(gameObject);
        }
    }

    IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Безопасный возврат на случай, если MyPool не был присвоен (защита)
        MyPool?.ReturnToPool(gameObject);
    }
}
