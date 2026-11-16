using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float currentSpeed;
    public float walkSpeed = 3f;
    public float sprintSpeed = 5f;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private CinemachineCamera _cinCam;

    private Vector2 _move;

    // Переменные для таймера отладки (Debug.Log)
    private float timer = 0f;
    private float logInterval = 1f; // Интервал в 1 секунду

    private void Start()
    {
        currentSpeed = walkSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnMove(InputValue val)
    {
        _move = val.Get<Vector2>();
    }

    private void Update()
    {
        // Проверяем, зажат ли Shift прямо сейчас через новый Input System (поддерживает и клавиатуру)
        if (Keyboard.current != null && Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // Движение персонажа
        _characterController.Move((GetForward() * _move.y + GetRight() * _move.x) * Time.deltaTime * currentSpeed);

        // Логирование трех переменных каждую секунду
    }

    private void HandleDebugLog()
    {
        // Прибавляем время кадра к таймеру
        timer += Time.deltaTime;

        // Когда прошла 1 секунда или больше
        if (timer >= logInterval)
        {
            // Выводим в консоль три переменные (например: currentSpeed, walkSpeed и значение по оси Y у вектора _move)
            Debug.Log($"Current Speed: {currentSpeed} | Walk Speed: {walkSpeed} | Move Y: {_move.y}");

            // Сбрасываем таймер, сохраняя «хвост» времени для точности
            timer -= logInterval;
        }
    }

    private Vector3 GetForward()
    {
        Vector3 forward = _cinCam.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetRight()
    {
        Vector3 right = _cinCam.transform.right;
        right.y = 0;
        return right.normalized;
    }
}