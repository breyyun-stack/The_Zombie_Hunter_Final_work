using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private int fireRange = 50;
    [SerializeField] private int _damage = 10;

    private RaycastHit hit;
    private Vector3 directionShot;
    
    private void OnEnable()
    {
        PlayerShootEvents.OnShoot += Shoot;
    }

    private void OnDisable()
    {
        PlayerShootEvents.OnShoot -= Shoot;
    }

    /// <summary>
    /// Выстрел
    /// </summary>
    public void Shoot()
    {
        // Берем начальные координаты выстрела и убираем координату y, чтобы выстрел был ровный
        directionShot = -transform.right;
        directionShot.y = 0;
        directionShot.Normalize();

        Physics.Raycast(transform.position, directionShot, out hit, fireRange);

        if (hit.collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(_damage);
            Debug.Log("Попадание в: " + hit.collider.name);
            Debug.DrawRay(transform.position, directionShot * fireRange, Color.red, 2f);
        }
        else
        {
            Debug.DrawRay(transform.position, directionShot * fireRange, Color.green, 2f);
        }

        //if (Physics.Raycast(transform.position, directionShot, out hit, fireRange))
        //{
        //    if (hit.collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
        //    {
        //        enemyHealth.TakeDamage(_damage);
        //        Debug.Log("Попадание в: " + hit.collider.name);
        //        Debug.DrawRay(transform.position, directionShot * fireRange, Color.red, 2f);
        //    }
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, directionShot * fireRange, Color.green, 2f);
        //}
    }
}
