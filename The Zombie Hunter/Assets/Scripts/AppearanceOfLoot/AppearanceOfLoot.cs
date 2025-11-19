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
    private float randomDistance;

    private Tweener rotationTween;

    public void OnEnable()
    {
        RandomDirectionXZ();

        var originalSize = transform.localScale;
        transform.localScale = Vector3.zero;

        newPosition = transform.position;
        newPosition.x = transform.position.x + randomDistance;
        newPosition.z = transform.position.z + randomDistance;

        transform.DOScale(originalSize, _timeOfAppearance);
        transform.DOMove(newPosition, _timeOfAppearance);

        rotationTween = transform

            // Вращение на 360 за определенное время
            .DORotate(Vector3.up * 360, _timeRotate)

            // Бесконечное вращение
            .SetLoops(-1)

            // Вокруг своей оси
            .SetRelative(true)

            // Без ускорений (линейное вращение)
            .SetEase(Ease.Linear);
    }

    private void RandomDirectionXZ()
    {
        // Выбираем случайный вектор в окружности
        Vector2 randomUnitVector = Random.insideUnitCircle.normalized;

        // Выбираем случайную дистанцию на которой будет появлятся лут
        randomDistance = Random.Range(_startRandomDistance, _endRandomDistance);

        randomDirectionXZ = new Vector3(randomUnitVector.x, 0f, randomUnitVector.y);
    }
}
