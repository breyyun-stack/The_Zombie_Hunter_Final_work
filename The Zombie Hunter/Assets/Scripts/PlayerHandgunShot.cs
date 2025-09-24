using UnityEngine;

public class PlayerHandgunShot : MonoBehaviour
{
    [SerializeField] private int fireRange = 100;

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
        directionShot = -transform.right;
        directionShot.y = 0;
        directionShot.Normalize();

        if (Physics.Raycast(transform.position, directionShot, out hit, fireRange))
        {
            Debug.Log("Попадание в: " + hit.collider.name);
            Debug.DrawRay(transform.position, directionShot * hit.distance, Color.red, 2f);
        }
        else
        {
            Debug.DrawRay(transform.position, directionShot * fireRange, Color.green, 2f);
        }
    }
}
