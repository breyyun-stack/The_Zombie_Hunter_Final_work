using UnityEngine;
using VContainer;

public class ExplodeMissileRocketLauncher : MonoBehaviour
{
    private bool gizmoExplode = false;
    private float explosionRadius;
    private int damage;
    private ObjectPool objectPool;

    public void Initialize(float explosionRadius, int damage, ObjectPool pool, bool gizmoExplode)
    {
        this.explosionRadius = explosionRadius;
        this.damage = damage;
        objectPool = pool;
        this.gizmoExplode = gizmoExplode;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();

        //Destroy(this.gameObject);
    }

    public void Explode()
    {
        // Получаем все коллайдеры в радиусе взрыва
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IEnemyHealth>(out IEnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        objectPool.ReturnToPool(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        if (gizmoExplode)
        {
            // Рисуем сферу даже если объект неактивен — удобно для настройки префаба
            Gizmos.color = new Color(1f, 0.3f, 0.3f, 0.4f); // полупрозрачный красный
            Gizmos.DrawSphere(transform.position, explosionRadius);
        }
    }
}
