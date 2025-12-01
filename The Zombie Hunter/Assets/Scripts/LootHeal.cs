using System.Collections;
using UnityEngine;

public class LootHeal : MonoBehaviour, IPoolable
{
    [SerializeField] private int _amount = 10;
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
        if (other.TryGetComponent<IPlayerHealth>(out IPlayerHealth playerHealth))
        {
            playerHealth.Heal(_amount);

            MyPool.ReturnToPool(gameObject);
        }
    }

    private void TimeUntilReturn(float time)
    {
        while (time > 0) 
        {
            time -= Time.deltaTime;
            Debug.Log($"time {time}");
        }

        if (time <= 0) 
        {
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
