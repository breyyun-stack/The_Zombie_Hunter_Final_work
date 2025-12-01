using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AppearanceOfLoot : MonoBehaviour
{
    [SerializeField] private int _timeOfAppearance = 1;
    [SerializeField] private float _timeRotate = 3f;
    [SerializeField] private float _startRandomDistance = 1;
    [SerializeField] private float _endRandomDistance = 2;

    private Vector3 newPosition;
    private Vector3 randomDirectionXZ;
    Vector2 randomUnitVector;
    private float randomDistance;

    public void OnEnable()
    {
        RandomDirectionXZ();

        var originalSize = transform.localScale;
        transform.localScale = Vector3.zero;

        newPosition = transform.position;
        newPosition.x = transform.position.x + randomUnitVector.x * randomDistance;
        newPosition.z = transform.position.z + randomUnitVector.y * randomDistance;

        transform.DOScale(originalSize, _timeOfAppearance);
        transform.DOMove(newPosition, _timeOfAppearance);

        transform

            // ¬ращение на 360 за определенное врем€
            .DORotate(Vector3.up * 360, _timeRotate)

            // Ѕесконечное вращение
            .SetLoops(-1)

            // ¬округ своей оси
            .SetRelative(true)

            // Ѕез ускорений (линейное вращение)
            .SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        transform.DOKill(complete: true);
    }

    /// <summary>
    /// —лучайна€ дистанци€ от врага, на которой будет по€вл€тс€ лут
    /// </summary>
    private void RandomDirectionXZ()
    {
        // ¬ыбираем случайный вектор в единичной окружности окружности
        randomUnitVector = Random.insideUnitCircle.normalized;

        // ¬ыбираем случайную дистанцию на которой будет по€вл€тс€ лут
        randomDistance = Random.Range(_startRandomDistance, _endRandomDistance);
    }
}
