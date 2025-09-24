using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private CinemachineCamera _freeLookCamera;

    private InputData inputData;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float currentSpeed;

    void Start()
    {
        inputData = GetComponent<InputData>();
        rb = GetComponent<Rigidbody>();
        currentSpeed = _walkSpeed;
    }

    void Update()
    {
        PlayerSprint(inputData.isSprint);
    }

    private void FixedUpdate()
    {
        RotationBehindCamera();

        PlayerMove();
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
    private void PlayerSprint(bool isSprint)
    {
        if (isSprint) 
        { 
            currentSpeed = _sprintSpeed; 
        }
        else
        {
            currentSpeed = _walkSpeed;
        }
    }
}
