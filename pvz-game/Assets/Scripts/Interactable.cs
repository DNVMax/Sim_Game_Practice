using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string promptMessage = "Нажмите E для взаимодействия";
    public string PromptMessage => promptMessage;

    public void Interact()
    {
        Debug.Log($"Взаимодействие с объектом: {gameObject.name}");
        // Здесь пишем логику: открыть дверь, подобрать предмет и т.д.
    }
}