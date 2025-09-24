using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private InputData inputData;
    private Animator animator;

    void Start()
    {
        inputData = GetComponent<InputData>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("x", inputData.inputVector.x);
        animator.SetFloat("y", inputData.inputVector.y);

        AnimationAttack(inputData.isAttack);
        AnimationReload(inputData.isReload);
        AnimationSprint(inputData.isSprint);
    }

    /// <summary>
    /// Анимация атаки
    /// </summary>
    /// <param name="isAttack"></param>
    private void AnimationAttack(bool isAttack)
    {
        animator.SetBool("isAttack", isAttack);
    }

    /// <summary>
    /// Анимация перезарядки
    /// </summary>
    /// <param name="isReload"></param>
    private void AnimationReload(bool isReload)
    {
        animator.SetBool("isReload", isReload);
    }

    /// <summary>
    /// Анимация ускорения
    /// </summary>
    private void AnimationSprint(bool isSprint)
    {
        animator.SetBool("isSprint", isSprint);
    }
}
