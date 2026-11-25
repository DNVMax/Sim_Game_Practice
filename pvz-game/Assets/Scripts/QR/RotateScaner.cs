using UnityEngine;
using UnityEngine.InputSystem;

// Автоматически гарантирует, что на объекте есть компонент Light
[RequireComponent(typeof(Light))]
public class RotateScaner : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Light spotLight;

    void Awake()
    {
        spotLight = GetComponent<Light>();
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Следование за игроком/камерой
        transform.rotation = target.rotation;
        transform.position = target.position;

        // Включаем свет, пока зажата левая кнопка мыши
        bool isPressed = Mouse.current != null && Mouse.current.leftButton.isPressed;

        // Меняем состояние только если оно действительно изменилось
        if (spotLight.enabled != isPressed)
        {
            spotLight.enabled = isPressed;
            Debug.Log($"Scanner light: {isPressed}");
        }
    }
}
