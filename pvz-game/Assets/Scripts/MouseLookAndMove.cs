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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxVerticalAngle, maxVerticalAngle);

        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);  

        transform.parent.Rotate(Vector3.up * mouseX);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.parent.right * horizontal + transform.parent.forward * vertical;
        transform.parent.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
