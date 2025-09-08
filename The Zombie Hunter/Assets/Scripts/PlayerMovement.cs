using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private CinemachineCamera _freeLookCamera;
    [SerializeField] private RuntimeAnimatorController[] _animatorOverride;
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private int _numberCurrentAnimator = 0;

    private InputData inputData;
    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float currentSpeed;

    void Start()
    {
        inputData = GetComponent<InputData>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = _walkSpeed;

        ResetAllWeapons();

        animator.runtimeAnimatorController = _animatorOverride[_numberCurrentAnimator];
        _weapons[_numberCurrentAnimator].SetActive(true);
    }

    void Update()
    {
        animator.SetFloat("x", inputData.inputVector.x);
        animator.SetFloat("y", inputData.inputVector.y);

        AnimationSprint(inputData.isSprint);
        AnimationAttack(inputData.isAttack);
        AnimationReload(inputData.isReload);
    }

    private void FixedUpdate()
    {
        RotationBehindCamera();

        PlayerMove();
    }

    private void ResetAllWeapons()
    {
        foreach (var weapon in _weapons)
        {
            weapon.SetActive(false);
        }
    }

    /// <summary>
    /// Вращение персонажа в направлении камеры
    /// </summary>
    private void RotationBehindCamera()
    {
        // Получаем направление камеры
        Vector3 cameraForward = _freeLookCamera.transform.forward;
        Vector3 cameraRight = _freeLookCamera.transform.right;

        // Игнорируем вертикальную составляющую (наклон камеры вверх/вниз)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Поворачиваем объект по направлению камеры, чтобы он постоянно смотрел вперед
        Vector3 dir = new Vector3(cameraForward.x, 0, cameraForward.z);
        transform.rotation = Quaternion.LookRotation(dir);

        // Вычисляем направление движения относительно камеры
        moveDirection = (cameraForward * inputData.inputVector.y + cameraRight * inputData.inputVector.x).normalized;
    }

    /// <summary>
    /// Движение игрока
    /// </summary>
    private void PlayerMove()
    {
        rb.MovePosition(rb.position + moveDirection * currentSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Анимация ускорения
    /// </summary>
    private void AnimationSprint(bool isSprint)
    {
        animator.SetBool("isSprint", isSprint);

        if (isSprint) 
        { 
            currentSpeed = _sprintSpeed; 
        }
        else
        {
            currentSpeed = _walkSpeed;
        }
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
}
