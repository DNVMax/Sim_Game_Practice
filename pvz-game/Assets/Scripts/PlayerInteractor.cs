using TMPro; // Обязательно подключаем пространство имен TextMeshPro
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactRange = 3f;

    [Header("UI Подсказка")]
    [SerializeField] private TextMeshProUGUI promptText; // Перетащите сюда ваш текст с экрана

    private void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        // При старте прячем подсказку
        HidePrompt();
    }

    private void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        if (playerCamera == null) return;

        // Создаем луч из центра экрана
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Пускаем луч на заданную дистанцию
        if (Physics.Raycast(ray, out hit, interactRange))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                // Показываем текст подсказки, который задан у объекта
                ShowPrompt(interactable.PromptMessage);

                // Если игрок нажал клавишу E
                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact();
                }
                return; // Выходим из метода, так как объект найден
            }
        }

        // Если луч никуда не попал или смотрит не на интерактивный предмет — прячем текст
        HidePrompt();
    }

    private void ShowPrompt(string message)
    {
        if (promptText != null)
        {
            promptText.text = message;
            promptText.gameObject.SetActive(true); // Включаем текст на экране
        }
    }

    private void HidePrompt()
    {
        if (promptText != null)
        {
            promptText.text = string.Empty;
            promptText.gameObject.SetActive(false); // Выключаем текст на экране
        }
    }
}