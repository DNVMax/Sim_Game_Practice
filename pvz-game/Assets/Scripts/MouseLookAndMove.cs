using UnityEngine;

public class MouseLookAndMove : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5.0f;

    [Header("Настройки мыши")]
    public float mouseSensitivity = 2.0f;
    public float maxVerticalAngle = 80.0f;

    private float rotationX = 0.0f;

    void Start()
    {
        // Блокируем курсор в центре экрана и скрываем его
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --- ВРАЩЕНИЕ КАМЕРЫ МЫШЬЮ ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxVerticalAngle, maxVerticalAngle);

        // Поворот головы вверх/вниз (самой камерой)
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);

        // Поворот тела влево/вправо (родительским объектом или текущим transform по оси Y)
        transform.parent.Rotate(Vector3.up * mouseX);

        // --- ДВИЖЕНИЕ С КЛАВИАТУРЫ (WASD) ---
        float horizontal = Input.GetAxis("Horizontal"); // A, D или Стрелки влево/вправо
        float vertical = Input.GetAxis("Vertical");     // W, S или Стрелки вверх/вниз

        Vector3 move = transform.parent.right * horizontal + transform.parent.forward * vertical;
        transform.parent.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
