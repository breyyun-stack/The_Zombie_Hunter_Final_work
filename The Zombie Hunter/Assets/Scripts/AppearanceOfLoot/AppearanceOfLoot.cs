using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AppearanceOfLoot : MonoBehaviour
{
    [SerializeField] private int timeOfAppearance = 1;

    private Vector3 newPosition;
    
    public void OnEnable()
    {
        var originalSize = transform.localScale;
        transform.localScale = Vector3.zero;

        newPosition = transform.position;
        newPosition.x = transform.position.x + 1f;
        newPosition.z = transform.position.z + 1f;

        transform.DOScale(originalSize, timeOfAppearance);
        transform.DOMove(newPosition, timeOfAppearance);
    }
}
